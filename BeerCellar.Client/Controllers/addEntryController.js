
var addEntryController = function addEntryController($scope, $http, $location) {
    $scope.add = function () {
        alert("Added!");
        $location.path("/");
    };
};