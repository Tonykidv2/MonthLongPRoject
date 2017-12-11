app.controller('EditEmployeeController', function ($scope, $location, SPAServices, SharedData) {

    loadEmployee();

    function loadEmployee() {
        var promiseGetEmployee = SPAServices.getEmployee(SharedData.value).
            then(SuccessError);


        function SuccessError(respond) {
            $scope.Employee = respond.data;
        }
    };

    loadAllStates();

    
    function loadAllStates() {
        var promiseGetStates = SPAServices.getStates(SharedData.value).
            then(SuccessError);

        function SuccessError(respond) {

            $scope.States = respond.data;
        };
    }

    $scope.FinalEdit = function () {
        var promiseDeleteEmployee = SPAServices.putEmployee(SharedData.value, $scope.Employee).
            then(SuccessError);

        function SuccessError(respond) {
            SharedData.value = 0;
            $location.path("/showemployees");
            $scope.check = respond.data;
        }
    };

    $scope.ReturnToList = function () {
        SharedData.value = 0;
        $location.path("/showemployees");
    };

});