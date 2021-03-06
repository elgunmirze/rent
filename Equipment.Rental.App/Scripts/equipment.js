﻿var app = angular
        .module("myModule", [])
    .controller("orderController", function ($scope, $http) {

        var apiUrl = "";
          $http.get("GetApiUrl")
              .then(function (response) {
                  apiUrl = response.data;
                    $http.get(response.data + "/api/equipments")
                        .then(function (response) {
                            $scope.equipments = response.data;
                        });
            });
        

     
        $scope.addToCart = function (id, rentDays, machineHashId) {
            var numbers = new RegExp(/^[0-9]+$/);
            if (!numbers.test(rentDays)) {
                alert('Enter numbers only');
            }
            else {
                var data =
                {
                    id: id,
                    rentDays: rentDays,
                    machineHashId: machineHashId
                };

                $http.post(apiUrl + "/api/addToCart", JSON.stringify(data))
                    .then(function (response) {
                        if (response.data === true) {
                            alert('**Added**');
                            $http.get(apiUrl + "/api/cartList?machineHashId=" + data.machineHashId)
                                .then(function (response) {
                                    $scope.cartList = response.data;
                                });
                        }
                        else {
                            alert('**Error**');
                        }
                    });
            }
        }


        $scope.prepareInvoice = function (data) {
            $http.get(apiUrl + "/api/cartList?machineHashId=" + data)
                .then(function (response) {

                    $http.post(apiUrl + "/api/invoice", JSON.stringify(response.data))
                        .then(function (response) {

                            var fileText = "Title: Invoice which is generated by the system" + "\n";

                            fileText = fileText + "\n"
                            fileText = fileText + "*******************************************" + "\n"
                            fileText = fileText + "\n"
                            response.data.orders.forEach(function (order) {
                                fileText = fileText + "\n"
                                    +"Name: " + order.name + " | "
                                    + "Rent days: " + order.rentDays + " | "
                                    + "Amount: "+ order.amount
                            });
                            fileText = fileText + "\n"
                            fileText = fileText + "*******************************************" + "\n"
                            fileText = fileText + "\n"
                                + "TotalAmount: " + response.data.totalAmount + "      "
                                + "Points: " + response.data.points

                            var fileName = "invoice" + Date.now() + ".txt";
                            saveTextAsFile(fileText, fileName);

                            $http.post(apiUrl + "/api/emptycartlist", JSON.stringify(data))
                                .then(function (result) {
                                    if (result.data === true) {
                                        alert("Invoice prepared !")
                                    }
                                    else {
                                        alert("Something happened wrong !")
                                    }
                                });

                            window.location.reload();
                        });
                });
        }
    })

function saveTextAsFile(data, filename) {

    if (!data) {
        console.error('Console.save: No data')
        return;
    }

    if (!filename) filename = 'console.json'

    var blob = new Blob([data], { type: 'text/plain' }),
        e = document.createEvent('MouseEvents'),
        a = document.createElement('a')

    if (window.navigator && window.navigator.msSaveOrOpenBlob) {
        window.navigator.msSaveOrOpenBlob(blob, filename);
    }
    else {
        var e = document.createEvent('MouseEvents'),
            a = document.createElement('a');

        a.download = filename;
        a.href = window.URL.createObjectURL(blob);
        a.dataset.downloadurl = ['text/plain', a.download, a.href].join(':');
        e.initEvent('click', true, false, window,
            0, 0, 0, 0, 0, false, false, false, false, 0, null);
        a.dispatchEvent(e);
    }
}