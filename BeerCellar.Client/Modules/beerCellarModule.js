// An angular module configures the injector
var beerCellarModule = angular.module('beerCellarModule', []);

// For now:
// In order to make calls to our service (which is on a different logical domain),
// we'll need this.  Theoretically this would be deployed to the same domain, and thus, not a problem.
beerCellarModule
  .config(function ($httpProvider) {
      delete $httpProvider.defaults.headers.common['X-Requested-With'];
  });