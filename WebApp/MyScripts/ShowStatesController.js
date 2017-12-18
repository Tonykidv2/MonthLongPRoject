app.controller('ShowStatesController', function ($scope, $location, SPAServices, SharedData) {

    $scope.isLoading = false;
    loadAllStates();

    
    function loadAllStates() {
        $scope.isLoading = true;
        var promiseGetStates = SPAServices.getStates(SharedData.value).
            then(SuccessError);

        function SuccessError(respond){

            $scope.States = respond.data;
            $scope.isLoading = false;
        };
    }
});