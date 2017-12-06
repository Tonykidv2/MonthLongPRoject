var app = angular.module("myApp", ["ngRoute"]);

app.factory("SharedData", function () {
    return { value: 1};
});

app.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
    debugger;

    $routeProvider.when('/showemployees',
        {
            templateUrl: 'EmployeeManagement/ShowEmployees',
            controller: 'ShowEmployeesController'
        });
    $routeProvider.when('/showstates', 
        {
            templateUrl: 'EmployeeManagement/ShowStates',
            controller: 'ShowStatesController'
        })
    $routeProvider.otherwise(
        {
            redirectTo: '/'
        });

    $locationProvider.html5Mode({ enabled: true, requireBase: false}).hashPrefix('!');

}]);