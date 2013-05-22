var beerCellarController = function ($scope, $http) {
    //$http.defaults.useXDomain = true;
    $http.get("http://localhost:49167/api/beercellar").success(function (data) {
        $scope.myBeers = data;
        refreshSummary();
    });

    var refreshSummary = function () {
        // grab the summary of my beers
        var beerSum = _.reduce($scope.myBeers, function (memo, entry) { return memo + entry.count; }, 0);
        var brewerySum = _.size(_.uniq($scope.myBeers, false, function (item) { return item.breweryName }));
        $scope.summary = { beerCount: beerSum, breweryCount: brewerySum };
    };
}
