// An angular module configures the injector
var app = angular.module('beerCellarModule', []);

// For now:
// In order to make calls to our service (which is on a different logical domain),
// we'll need this.  Theoretically this would be deployed to the same domain, and thus, not a problem.
app.config(function ($httpProvider, $routeProvider, $locationProvider) {
    delete $httpProvider.defaults.headers.common['X-Requested-With'];
    $routeProvider
        .when("/", { templateUrl: "views/partials/list.html" })
        .when("/new", { templateUrl: "views/partials/new.html", controller: "addEntryController" });
    $locationProvider.html5Mode(true);
});

app.directive("summary", function () {
    return {
        restrict: "E",
        template: "<div>Summary:  I have {{summary.beerCount}} beers from {{summary.breweryCount}} breweries.</div>",
        link: function (scope, element) {
            element.bind("mouseenter", function () {

            });
        }
    };
});

app.directive("adam", function () {
    return {
        restrict: "A",
        template:"my name is adam!",
        link: function (scope, element, attrs) {
            element.bind("mouseenter", function () {
                alert("hello adam");
            });
        }
    };
});


