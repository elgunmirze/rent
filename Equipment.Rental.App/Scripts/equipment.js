var app = angular
        .module("myModule", [])
    .controller("orderController", function ($scope, $http) {
        $http.get("http://localhost/api/equipments")
            .then(function (response) {
                $scope.equipments = response.data;
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

                $http.post("http://localhost/api/addToCart", JSON.stringify(data))
                    .then(function (response) {
                        if (response.data === true) {
                            alert('**Added**');
                            $http.get("http://localhost/api/cartList?machineHashId=" + data.machineHashId)
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
            $http.get("http://localhost/api/cartList?machineHashId=" + data)
                .then(function (response) {

                    $http.post("http://localhost/api/invoice", JSON.stringify(response.data))
                        .then(function (response) {

                            var fileText = "";
                            response.data.orders.forEach(function (order) {
                                fileText = fileText +"\n"+ order.id + " " + order.name;

                            });

                            var fileName = "invoice" + Date.now() + ".txt";
                            saveTextAsFile(fileText, fileName);
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