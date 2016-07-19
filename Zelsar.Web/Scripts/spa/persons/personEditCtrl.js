(function (app) {
    'use strict';

    app.controller('personEditCtrl', personEditCtrl);

    personEditCtrl.$inject = ['$scope', '$modalInstance', '$timeout', 'apiService'];

    function personEditCtrl($scope, $modalInstance, $timeout, apiService) {

        $scope.cancelEdit = cancelEdit;
        $scope.updatePerson = updatePerson;


        function updatePerson() {
            apiService.post('/api/Site/updatePerson/', $scope.EditedPerson,
            updatePersonCompleted,
            updatePersonLoadFailed);
        }

        function updatePersonCompleted(response) {
            $scope.EditedPerson = {};
            $modalInstance.dismiss();
        }

        function updatePersonLoadFailed(response) {
           
        }

        function cancelEdit() {
            $scope.isEnabled = false;
            $modalInstance.dismiss();
        }

     

    }

})(angular.module('homeZelsar'));