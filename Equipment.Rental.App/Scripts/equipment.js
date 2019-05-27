var app = angular
        .module("myModule", [])
    .controller("orderController", function ($scope, $http) {
        $http.get("GetAllEquipments")
            .then(function (response) {
                $scope.employees = response.data;
            });
        $scope.addToCart = function (id, rentDays) {
            var numbers = new RegExp(/^[0-9]+$/);
            if (!numbers.test(rentDays)) {
                alert('Enter numbers only');
            }
            else {
                var data = {
                    id: id,
                    rentDays: rentDays
                };
                $http.post("AddToCart", JSON.stringify(data))
                    .then(function (response) {
                        $scope.cartList = response.data;
                    });
            }
        }
    })