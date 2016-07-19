(function (app) {
    'use strict';

    app.controller('personRegCtrl', personRegCtrl);

    personRegCtrl.$inject = ['$scope', '$location', '$rootScope', 'apiService', 'notificationService'];

    function personRegCtrl($scope, $location, $rootScope, apiService, notificationService) {

        $scope.newPerson = {};

        $scope.Register = Register;

        function Register() {
           $scope.newPerson.Active = true;
           apiService.post('api/Site/InsertPerson', $scope.newPerson,
           registerPersonSucceded,
           registerPersonFailed);
        }

        function registerPersonSucceded(response) {
            var person = response.data;
            notificationService.displaySuccess('New customer with ID ' + person.Id + ' ' + ' has been added');
            $scope.newCustomer = {};
        }

        function registerPersonFailed(response) {
            var error = response.data.$values;
            notificationService.displayError(error);
        }


    }

})(angular.module('homeZelsar'));