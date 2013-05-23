
var addEntryController = function addEntryController($scope, $http, $location, pubSub) {
    // this is our model
    $scope.entry = { beerName: "", breweryName: "", count: "", year: "" };

    // Add a beer to our cellar
    $scope.add = function () {
        var json = JSON.stringify($scope.entry);
        $http.post('http://localhost:49167/api/beercellar', json).success(function () {
            pubSub.prepareBroadcast("beerCellarController", "refreshList")
            $location.path("/");
        }).error(function (data, status, headers, config) {
            alert(data);
        });
    };
};