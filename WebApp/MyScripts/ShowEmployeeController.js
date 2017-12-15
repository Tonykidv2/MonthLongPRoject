app.controller('ShowEmployeeController', function ($scope, $location, SPAServices, SharedData) {

    loadEmployee();

    function loadEmployee() {
        if (ShardedData.value != 0) {
            var promiseGetEmployee = SPAServices.getEmployee(SharedData.value).
               then(SuccessError);
        }
        else {
            $scope.Employee.Name = "";
            $scope.Employee.ID = 0;
            $scope.Employee.Email = "";
            $scope.Employee.PhoneNumber = 0;
            $scope.Employee.Age = 0;
            $scope.Employee.DOB = "";
            $scope.Employee.state = {};
            $scope.Employee.isMale = 0;
        }
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
    };

    loadAllStates();
    function loadAllStates() {
        var promiseGetEmployees = SPAServices.getStates(SharedData.value).
            then(SuccessError);


        function SuccessError(respond) {
            $scope.Educations = respond.data;
        }
    };

    $scope.AddEmployee = function () {
        SPAServices.postEmployee($scope.Employee).
            then(SuccessError);

        function SuccessError(respond) {
            $scope.errorCheck = respond.data;
        };
    };

    $scope.EditEmployee = function () {
        SPAServices.putEmployee(SharedData.value, $scope.Employee).
            then(SuccessError);

        function SuccessError(respond) {
            $scope.errorCheck = respond.data;
        };
    };
    
    $scope.ReturnToList = function () {
        SharedData.value = 0;
        $location.path("/showemployees");
    };
});