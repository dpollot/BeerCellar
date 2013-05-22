var beerCellarController = function ($scope, $http) {
    //$http.defaults.useXDomain = true;
    $http.get("http://localhost:49167/api/beercellar").success(function (data) {
        $scope.myBeers = data;
    });
}
