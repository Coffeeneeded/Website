﻿
var HomeController = function ($scope) {
    
    $scope.models = {
        helloAngular: 'I workkk!'
    };
}

// The $inject property of every controller (and pretty much every other type of object in Angular) needs to be a string array equal to the controllers arguments, only as strings
HomeController.$inject = ['$scope'];