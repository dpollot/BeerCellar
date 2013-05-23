var beerCellarController = function ($scope, $http, pubSub) {

    // Pagination
    $scope.currentPage = 0;
    $scope.pageSize = 5; 

    // Load the list of my beers
    var loadList = function () {
        $http.get("http://localhost:49167/api/beercellar").success(function (data) {
            $scope.myBeers = data;
            $scope.pageCount = window.Math.ceil($scope.myBeers.length / $scope.pageSize);
            refreshSummary();
        });
    };

    // Refresh the summary of my beers
    var refreshSummary = function () {
        // grab the summary of my beers
        var beerSum = _.reduce($scope.myBeers, function (memo, entry) { return memo + entry.count; }, 0);
        var brewerySum = _.size(_.uniq($scope.myBeers, false, function (item) { return item.breweryName }));
        $scope.summary = { beerCount: beerSum, breweryCount: brewerySum };
    };

    // Update Quantities
    $scope.updateQuantity = function (dir, beer) {
        if (beer.count + dir >= 0)
            beer.count += dir;

        $http.put("http://localhost:49167/api/beercellar", JSON.stringify(beer))
            .success(function () {
                alert("updated!");
            })
            .error(function (data, status, headers, config) {

            });
    }

    $scope.$on('handleBroadcast', function () {
        if (pubSub.topic == 'beerCellarController' && pubSub.body == 'refreshList') {
            loadList();
        }
    });

    loadList();
}
