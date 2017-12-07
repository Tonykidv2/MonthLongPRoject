app.controller('ShowEmployeesController', function ($scope, $location, SPAServices, SharedData) {

    loadAllEmployees();

    function loadAllEmployees() {
        var promiseGetEmployees = SPAServices.getEmployees(SharedData.value).
            then(SuccessError);


        function SuccessError(respond) {
            $scope.Employees = respond.data;
        }
    }
});