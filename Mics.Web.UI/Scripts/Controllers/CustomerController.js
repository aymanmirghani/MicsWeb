/// <reference path="../angular.min.js" />
var app = angular.module("MicsApp", []);
app.controller("getAllCustomersController", getAllCustomersController);
function getAllCustomersController($scope, $http) {
    $scope.customers = [];
    
    $http.get('/micswebapi/api/customers')
      .then(function (result) {
          $scope.customers = result.data;
          
      });
}
//$scope.controller("getAllCustomersController");