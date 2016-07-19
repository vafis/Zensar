(function () {
    'use strict';

    angular.module('homeZelsar', ['common.core', 'common.ui'])
        .config(config);
        

    config.$inject = ['$routeProvider'];
    function config($routeProvider) {
        $routeProvider
            .when("/", {
                templateUrl: "scripts/spa/home/index.html",
                controller: "indexCtrl"
            })
            .when("/persons", {
                templateUrl: "scripts/spa/persons/persons.html",
                controller: "personsCtrl"
            })
            .when("/persons/register", {
                  templateUrl: "scripts/spa/persons/personReg.html",
                  controller: "personRegCtrl"
        }).otherwise({ redirectTo: "/" });
    }

})();