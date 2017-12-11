app.controller('DeleteEmployeeController', function ($scope, $location, SPAServices, SharedData) {

    loadEmployee();

    function loadEmployee() {
        var promiseGetEmployee = SPAServices.getEmployee(SharedData.value).
            then(SuccessError);


        function SuccessError(respond) {
            $scope.Employee = respond.data;
        }
    };
    
    $scope.FinalDelete = function() {
        var promiseDeleteEmployee = SPAServices.deleteEmployee(SharedData.value).
            then(SuccessError);

        function SuccessError(respond) {
            SharedData.value = 0;
            $location.path("/showemployees");
            $scope.check = respond.data;
        }
    };

    $scope.ReturnToList = function() {
        SharedData.value = 0;
        $location.path("/showemployees");
    };

});