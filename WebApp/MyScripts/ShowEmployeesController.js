app.controller('ShowEmployeesController', function ($scope, $location, SPAServices, SharedData) {

    loadAllEmployees();

    function loadAllEmployees() {
        var promiseGetEmployees = SPAServices.getEmployees(SharedData.value).
            then(SuccessError);


        function SuccessError(respond) {
            $scope.Employees = respond.data;
        }
    };

    $scope.editEmployee = function (id) {
        SharedData.value = id;
        $location.path("/editEmployee");
    };

    $scope.deleteEmployee = function (id) {
        SharedData.value = id;
        $location.path("/deleteEmployee");
    };
});