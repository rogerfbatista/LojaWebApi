
var app = angular.module('AngularAuthApp');

app.controller('contatoController', ['$scope', '$modal',  '$routeParams', '$location', 'authService', 'Contato',
        function ($scope, $modal, $routeParams, $location, authService, Contato) {

            $scope.authentication = authService.authentication;

            $scope.email = {};

            $scope.alerts = {
                items: [],
                add: function (type, msg) {
                    this.items.push({ type: type, msg: msg });
                },
                update: function (type, msg) {
                    this.items.push({ type: type, msg: msg });
                },
                close: function (index) {
                    this.items.splice(index, 1);
                }
            };

            $scope.enviar = function () {

                $scope.$broadcast('show-errors-check-validity');

                if ($scope.userForm.$valid) {

                    Contato.save(JSON.stringify($scope.email), function () {
                        $scope.email = {};
                        $location.path('/contato');
                    },function (error) {

                           $scope.alerts.add('success', error.data.exceptionMessage == undefined ? error.data.message : error.data.exceptionMessage);
                        });
                }
            };

        }]);



