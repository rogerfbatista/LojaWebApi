
    'use strict';

    var app = angular.module('AngularAuthApp');

    app.controller('modalController', ['$scope', '$modalInstance', 'items', function ($scope, $modalInstance, items) {
        
        $scope.confirm = function () {
            $modalInstance.close(items);
        };

        $scope.cancel = function () {
            $modalInstance.dismiss('cancel');
        };


    }]);
