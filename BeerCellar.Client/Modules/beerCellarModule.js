// An angular module configures the injector
var app = angular.module('beerCellarModule', []);

// Injecting services into controllers.
// Sometimes we need to communicate between controllers... shit happens.
// So... let's create a simple pub/sub service.
app.factory('pubSub', function ($rootScope) {
    var pubSub = {};
    
    pubSub.topic = "";
    pubSub.body = {};

    pubSub.prepareBroadcast = function (topic, body) {
        this.topic = topic;
        this.body = body;

        this.broadcast();
    };

    pubSub.broadcast = function () {
        $rootScope.$broadcast('handleBroadcast');
    };

    return pubSub;
});

app.config(function ($httpProvider, $routeProvider, $locationProvider) {

    // For now:
    // In order to make calls to our service (which is on a different logical domain),
    // we'll need this.  Theoretically this would be deployed to the same domain, and thus, not a problem.
    delete $httpProvider.defaults.headers.common['X-Requested-With'];

    // Routing!
    $routeProvider
        .when("/", { templateUrl: "views/partials/list.html" })
        .when("/new", { templateUrl: "views/partials/new.html", controller: "addEntryController" });
    $locationProvider.html5Mode(true);
});

// Directives!
app.directive("summary", function () {
    return {
        // We can restrict to [E(element)|A(attribute)|C(class)|M(comment)]
        restrict: "E",
        // We can provide any template - and that template can contain databinding expressions
        template: "<div><h2>Summary:  I have {{summary.beerCount}} beers from {{summary.breweryCount}} breweries.</h2></div>",
        // The linking function is called when the directive is first compiled in
        link: function (scope, element) {
            // This could really be anything...
            element.bind("mouseenter", function () {

            });
        }
    };
});

// Custom Filter for Pagination
app.filter('startingPoint', function () {
    return function (input, start) {
        start = +start;
        return input.slice(start);
    }
});


