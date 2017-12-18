app.controller('ShowEmployeesController', function ($scope, $location, SPAServices, SharedData) {

    $scope.Employees = []
    loadAllEmployees();
    $scope.currentPage = 0;
    $scope.pageSize = 10;
    $scope.showHints = true;
    $scope.numberOfPages = function () {
        return Math.ceil($scope.Employees.length / $scope.pageSize);
    };

    function loadAllEmployees() {
        var promiseGetEmployees = SPAServices.getEmployees(SharedData.value).
            then(SuccessError);


        function SuccessError(respond) {
            $scope.Employees = respond.data;
        }
    };
    loadAllStates();
    function loadAllStates() {
        var promiseGetEmployees = SPAServices.getStates(SharedData.value).
            then(SuccessError);


        function SuccessError(respond) {
            $scope.States = respond.data;
        }
    };

    loadAllEducations();
    function loadAllEducations() {
        var promiseGetEmployees = SPAServices.getEducations().
            then(SuccessError);


        function SuccessError(respond) {
            $scope.Educations = respond.data;
        }
    };

    $scope.editEmployee = function (id) {
        SharedData.value = id;
        $location.path("/editEmployee");
    };

    $scope.ShowEmployee = function (id) {
        SharedData.value = id;
        $location.path("/showemployee");
    };

    $scope.deleteEmployee = function (id) {
        SharedData.value = id;
        $location.path("/deleteEmployee");
    };

    $scope.nextPage = function () {
        $scope.currentPage = $scope.currentPage + 1
    };

    $scope.prevPage = function () {
        $scope.currentPage = $scope.currentPage - 1
    };

    $scope.ResetPage = function () {
        $scope.currentPage = 0;
    };

    $scope.onlyAlphabets = function (e, t) {
        try {
            if (window.event) {
                var charCode = window.event.keyCode;
            }
            else if (e) {
                var charCode = e.which;
            }
            else { return true; }
            if ((charCode > 64 && charCode < 91) || (charCode > 96 && charCode < 123))
                return true;
            else
                return false;
        }
        catch (err) {
            alert(err.Description);
        }
    };

    $scope.user = {
        name: "",
        email: "",
        social: "123456789",
        phone: ""
    };
});

function onlyAlphabets(e, t) {
    try {
        if (window.event) {
            var charCode = window.event.keyCode;
        }
        else if (e) {
            var charCode = e.which;
        }
        else { return true; }
        if ((charCode > 64 && charCode < 91) || (charCode > 96 && charCode < 123))
            return true;
        else
            return false;
    }
    catch (err) {
        alert(err.Description);
    }
};

app.filter('startFrom', function () {
    return function (input, start) {
        if (!input || !input.length) { return; }
        start = +start; //parse to int
        return input.slice(start);
    };
});