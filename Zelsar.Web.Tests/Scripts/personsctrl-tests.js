'use strict';

(function() {

    describe('spec', function() {
        var scope, controller, apiServiceMock, persons;

        beforeEach(function () {
            module('homeZelsar');

            inject(function ($rootScope, $controller, apiService) {
                scope = $rootScope.$new();
                apiServiceMock = sinon.stub(apiService);
                persons = [{ Name: 'Kostas' }];
                apiServiceMock.get.returns(persons);
                controller = $controller('personsCtrl', { $scope: scope });
            });

            it('should return persons', function() {
                expect(scope.search).toBe(persons);
            });
        });
    });






}());