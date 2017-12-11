app.service("SPAServices", function ($http) {

    this.getEmployees = function (id) {
        return $http.get("http://localhost:6086/api/employee/getall");
    };

    this.getStates = function (id) {
        var some = $http.get("http://localhost:6086/api/state/getall");
        return some;
    };

    this.getEmployee = function (id) {
        return $http.get("http://localhost:6086/api/employee/" + id);
    };

    this.deleteEmployee = function (id) {
        var request = $http.delete("http://localhost:6086/api/employee/" + id);
        return request;
    };

    this.dEmployee = function (id) {
        return $.ajax({
            type: 'DELETE',
            url: "http://localhost:6086/api/employee/" + id,
            dataType: 'json'
        });
    };

    this.putEmployee = function (id, employee) {
        var request = $http({
            method: "PUT",
            url: "http://localhost:6086/api/employee/" + id,
            data: employee
        });
        return request;

        //return $.ajax({
        //    type: 'PUT',
        //    url: "http://localhost:6086/api/employee/" + id,
        //    data: employee
        //});
    };

    this.postEmployee = function (employee) {
        
        var request = $http({
            method: 'POST',
            url: "http://localhost:6086/api/employee/",
            data: employee
        });
        return request;
    }

});