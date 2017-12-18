var app = angular.module("myApp", ["ngRoute", 'ngMaterial', 'ngMessages']);

app.factory("SharedData", function () {
    return { value: 0};
});

app.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
    debugger;

    $routeProvider.when('/showemployees',
        {
            templateUrl: 'EmployeeManagement/ShowEmployees',
            controller: 'ShowEmployeesController'
        });
    $routeProvider.when('/showemployee',
        {
            templateUrl: 'EmployeeManagement/ShowingEmployee',
            controller: 'ShowEmployeeController'
        });
    $routeProvider.when('/showstates',
        {
            templateUrl: 'EmployeeManagement/ShowStates',
            controller: 'ShowStatesController'
        });
    $routeProvider.when('/editEmployee',
        {
            templateUrl: 'EmployeeManagement/EEmployee',
            controller: 'EditEmployeeController'
        });
    $routeProvider.when('/deleteEmployee',
        {
            templateUrl: 'EmployeeManagement/DEmployee',
            controller: 'DeleteEmployeeController'
        });

    $routeProvider.otherwise(
        {
            redirectTo: '/'
        });

    $locationProvider.html5Mode({ enabled: true, requireBase: false}).hashPrefix('!');

}]);

//app.config(['$httpProvider', function ($httpProvider) {
//    $httpProvider.defaults.headers.common = {};
//    $httpProvider.defaults.headers.post = {};
//    $httpProvider.defaults.headers.put = {};
//    $httpProvider.defaults.headers.patch = {};
//    $httpProvider.defaults.headers.delete = {};
//}]);