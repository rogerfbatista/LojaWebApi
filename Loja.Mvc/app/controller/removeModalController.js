(function () {
    'use strict';

    var app = angular.module('AngularAuthApp');

    app.controller('removeModalController', ['$scope', '$modalInstance', 'items', function ($scope, $modalInstance, items) {
        $scope.obj = items.obj;

        $scope.confirm = function () {
            $modalInstance.close(items);
        };

        $scope.cancel = function () {
            $modalInstance.dismiss('cancel');
        };
    }]);
})();