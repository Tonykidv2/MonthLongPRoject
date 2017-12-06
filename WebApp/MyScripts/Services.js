app.service("SPAServices", function ($http) {

    this.getEmployees = function (id) {
        return $http.get("http://localhost:6086/api/employee?id=" + id);
    };
    this.getStates = function (id) {
        var some = $http.get("http://localhost:6086/api/state")
        return some;
    };
});