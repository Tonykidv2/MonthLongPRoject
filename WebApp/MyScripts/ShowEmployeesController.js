app.controller('ShowEmployeesController', function ($scope, $location, SPAServices, SharedData) {

    loadAllEmployees();

    function loadAllEmployees() {
        var promiseGetEmployees = SPAServices.getEmployees(SharedData.value).
            then(function (pl) { $scope.Employees = pl.data },
                function (errorPl) {
                    $scope.error = errorPl;
            });
    }
});