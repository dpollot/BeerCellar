
var addEntryController = function addEntryController($scope, $http, $location) {
    $scope.entry = { beerName: "", breweryName: "", count: "", year: "" };
    $scope.add = function () {

        var json = JSON.stringify($scope.entry);
        $http.post('http://localhost:49167/api/beercellar', json).success(function () {
            alert("Added!");
            $location.path("/");
        }).error(function (data, status, headers, config) {
            alert(data);
        });
    };
};