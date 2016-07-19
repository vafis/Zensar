(function (app) {
    'use strict';

    app.controller('personsCtrl', personsCtrl);

    personsCtrl.$inject = ['$scope', '$modal', 'apiService'];

    function personsCtrl($scope, $modal, apiService) {

        $scope.persons = [];
        $scope.search = search;
        $scope.openEditDialog = openEditDialog;

        function search() {

            apiService.get('api/Site/GetPersons', null,
                personsLoadCompleted,
                personsLoadFailed);
        }

        function openEditDialog(person) {
            $scope.EditedPerson = person;
            $modal.open({
                templateUrl: 'scripts/spa/persons/editPersonModal.html',
                controller: 'personEditCtrl',
                scope: $scope
            }).result.then(function($scope) {
                var i = 11;
            }, function() {
            });
        }

        function personsLoadCompleted(result) {
            $scope.persons = result.data.$values;
            $scope.loadingPersons = false;

        }

        function personsLoadFailed(response) {

        }

        $scope.search();

    }
})(angular.module('homeZelsar'));