var InterfaceCore = angular.module('InterfaceCoreModule', ['ngRoute', 'ui.bootstrap']);

InterfaceCore.controller('HomeController', HomeController);

var configFunction = function ($routeProvider) {
    $routeProvider.
        when('/routeOne', {
            templateUrl: 'routesDemo/one'
        })
        .when('/routeTwo', {
            templateUrl: 'routesDemo/two'
        })
        .when('/routeThree', {
            templateUrl: 'routesDemo/three'
        });
}
configFunction.$inject = ['$routeProvider'];

InterfaceCore.config(configFunction);
