
var app = angular.module('AngularAuthApp');

app.controller('produtoTipoController', ['$scope', '$modal', 'ProdutoTipo', 'NgTableParams', '$filter',
                '$routeParams', '$location', '$timeout',
        function ($scope, $modal, ProdutoTipo, NgTableParams, $filter, $routeParams, $location, $timeout) {

            $scope.cabecalho = 'Cadastro de ';
            $scope.btn = 'Adicionar';

            $scope.produtoTipo = {
                "produtoTipoId": 0,
                "nomeProdutoTipo": "",
                "ativo": true,
                "produtos": []
            };




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


            //adicionar

            $scope.save = function () {

                $scope.$broadcast('show-errors-check-validity');

                if ($scope.userForm.$valid) {
                    ProdutoTipo.save(JSON.stringify($scope.produtoTipo), function () {
                        $location.path('/produtotipo');
                    },
                    function (error) {

                        $scope.alerts.add('success', error.data.exceptionMessage == undefined ? error.data.message : error.data.exceptionMessage);
                    });
                }

            };

            //alterar
            $scope.update = function () {

                $scope.$broadcast('show-errors-check-validity');

                if ($scope.userForm.$valid) {
                    ProdutoTipo.update(JSON.stringify($scope.produtoTipo), function () {
                        $location.path('/produtotipo');

                    },
                    function (error) {

                        $scope.alerts.add('success', error.data.exceptionMessage == undefined ? error.data.message : error.data.exceptionMessage);
                    });
                }
            };

            if ($location.path().indexOf('update') > 0) {

                $scope.cabecalho = 'Alterar ';
                $scope.btn = 'Alterar';

                ProdutoTipo.get({ id: $routeParams.id }).$promise.then(function (response) {
                    $scope.produtoTipo = response;

                }, function (error) {

                    $scope.alerts.add('success', error.data.exceptionMessage == undefined ? error.data.message : error.data.exceptionMessage);
                });


            };

            $scope.salvar = function () {

                $timeout(function () {
                    if ($scope.produtoTipo.produtoTipoId > 0)
                        $scope.update();
                    else
                        $scope.save();
                });
            };

            $scope.moveUpdate = function (id) {

                var location = '/produtotipo/update/' + id;


                $location.path(location);
            };


            if ($location.path() == "/produtotipo") {


                $scope.gridDirective = {
                    delete: {
                        method: ProdutoTipo.delete,
                        mensagemAfterDelete: 'O Tipo de Produto',
                        id: 'produtoTipoId'
                    },
                    update: {
                        method: $scope.moveUpdate,
                        id: 'produtoTipoId'
                    },
                    enableSearchText: true,
                    paginationPageSizes: [10, 25, 50],
                    paginationPageSize: 10,
                    enablePaginationControls: true,
                    columnDefs: [
                                { name: 'Nome', field: 'nomeProdutoTipo' },
                                 { name: 'Açoes', cellTemplate: ' <button type="button" class="btn btn-default" ng-click="grid.appScope.btnRemove(row)">  <span class="glyphicon glyphicon-remove-circle"></span> </button>  <button type="button" class="btn btn-default" ng-click="grid.appScope.btnUpdate(row)"> <span class="glyphicon glyphicon-pencil"></span></button>' }],
                    get: ProdutoTipo.query,
                    onRegisterApi: function (gridApi) {
                        $scope.gridApi = gridApi;
                    }
                };

            }

            $timeout(function () {

                $("script[src='http://ads.mgmt.somee.com/serveimages/ad2/WholeInsert4.js']").remove();
                $("div[onmouseover]").remove();
                $("div[style*='height: 65px']").remove();
                $("center").find('a').remove();
            }, 3000);

        }]);



