app.controller('ShowEmployeeController', function ($scope, $location, SPAServices, SharedData) {

    loadEmployee();

    function loadEmployee() {
        if (SharedData.value != 0) {
            var promiseGetEmployee = SPAServices.getEmployee(SharedData.value).
               then(SuccessError);
        }
        else {
            $scope.Employee = {};
            $scope.Employee.Name = "";
            $scope.Employee.ID = 0;
            $scope.Employee.Email = "";
            $scope.Employee.PhoneNumber = "";
            $scope.Employee.Age = 0;
            $scope.Employee.DOB = "";
            $scope.Employee.state = {};
            $scope.Employee.isMale = false;
            $scope.Employee.edu;
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

    loadAllEducation();
    function loadAllEducation() {
        var promiseGetEmployees = SPAServices.getEducations(SharedData.value).
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
            if ($scope.errorCheck == true) {
                SharedData.value = 0;
                $location.path("/showemployees");
            }
        };
    };

    $scope.EditEmployee = function () {
        SPAServices.putEmployee(SharedData.value, $scope.Employee).
            then(SuccessError);

        function SuccessError(respond) {
            $scope.errorCheck = respond.data;
            if ($scope.errorCheck == true) {
                SharedData.value = 0;
                $location.path("/showemployees");
            }
        };
    };
    
    $scope.DeleteEmployee = function () {
        SPAServices.deleteEmployee(SharedData.value).
            then(SuccessError);

        function SuccessError(respond) {
            $scope.errorCheck = respond.data;
            if (errorCheck == "Entry Delete")
            {
                SharedData.value = 0;
                $location.path("/showemployees");}
            };
    };

    $scope.ReturnToList = function () {
        SharedData.value = 0;
        $location.path("/showemployees");
    };
});