var myApp = angular.module('myApp', ['ngRoute']);

myApp.config(['$routeProvider', '$locationProvider',function ($routeProvider) {
    $routeProvider
    .when('/', {
        templateUrl: 'Templates/index.html',
        controller: 'mainController'
    })
    .when('/About', {
        templateUrl: 'Templates/About.html',
        controller: 'mainController'
    })
}]);

myApp.controller('mainController', ['$scope', '$log', function ($scope, $log) {

}]);