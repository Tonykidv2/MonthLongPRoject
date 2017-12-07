app.controller('ShowStatesController', function ($scope, $location, SPAServices, SharedData) {

    loadAllStates();

    
    function loadAllStates() {
        var promiseGetStates = SPAServices.getStates(SharedData.value).
            then(SuccessError);

        function SuccessError(respond){

            $scope.States = respond.data;
        };
    }
});