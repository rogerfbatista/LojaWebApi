
var app = angular.module('AngularAuthApp');

app.controller('produtoController', ['$scope', '$modal', 'Produto','ProdutoTipo', 'NgTableParams', '$filter',
                '$routeParams', '$location', 'authService','$timeout',
        function ($scope, $modal, Produto, ProdutoTipo, NgTableParams, $filter, $routeParams, $location, authService, $timeout) {

            $scope.cabecalho = 'Cadastro de ';
            $scope.btn = 'Adicionar';

            $scope.authentication = authService.authentication;

            $scope.produtoTipo = [];

            $scope.produto = {
                "produtoId": 0,
                "produtoTipoId": 0,
                "empresaId": $scope.authentication.empresaId,
                "codigoReferencia": "",
                "nomeProduto": "",
                "dataCastro": null,
                "imagemCliente": null,
                "ativo": true,
                "produtoClienteSaidas": [],
                "produtoEstoques": [],
                "produtoFornecedorEntradas": [],
                "produtoTipo": null
               
            };


         

            if ($location.path().indexOf('new') > 0 || $location.path().indexOf('update') > 0) {

                ProdutoTipo.query().$promise.then(function (result) {

                    $scope.produtoTipo = result;
                }, function (error) {
                   $scope.alerts.add('success', error.data.exceptionMessage == undefined ? error.data.message : error.data.exceptionMessage);
                });

            }
            
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

                    Produto.save(JSON.stringify($scope.produto), function () {
                        $location.path('/produto');
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
                    Produto.update(JSON.stringify($scope.produto), function () {
                        $location.path('/produto');

                    },
                    function (error) {

                       $scope.alerts.add('success', error.data.exceptionMessage == undefined ? error.data.message : error.data.exceptionMessage);
                    });
                }
            };

            if ($location.path().indexOf('update') > 0) {

                $scope.cabecalho = 'Alterar ';
                $scope.btn = 'Alterar';


                Produto.get({ id: $routeParams.id }).$promise.then(function (response) {
                    $scope.produto = response;

                }, function (error) {

                   $scope.alerts.add('success', error.data.exceptionMessage == undefined ? error.data.message : error.data.exceptionMessage);
                });


            };

            $scope.moveUpdate = function (id) {

                var location = '/produto/update/' + id;


                $location.path(location);
            };

            $scope.salvar = function () {

                $timeout(function () {
                    if ($scope.produto.produtoId > 0)
                        $scope.update();
                    else
                        $scope.save();
                });
            };


            if ($location.path() == "/produto") {


                $scope.gridDirective = {
                    delete: {
                        method: Produto.delete,
                        mensagemAfterDelete: 'O Produto',
                        id: 'produtoId'
                    },
                    update: {
                        method: $scope.moveUpdate,
                        id: 'produtoId'
                    },
                    enableSearchText: true,
                    paginationPageSizes: [10, 25, 50],
                    paginationPageSize: 10,
                    enablePaginationControls: true,
                    columnDefs: [
                                { name: 'Nome', field: 'nomeProduto' },
                                 { name: 'Código', field: 'codigoReferencia' },
                                 { name: 'Logo', field: 'imagemCliente', cellTemplate: "<img style='width: 10%;' data-ng-src='data:image/jpeg;base64,{{row.entity.imagemCliente}}' alt='' />" },
                                 { name: 'Açoes', cellTemplate: ' <button type="button" class="btn btn-default" ng-click="grid.appScope.btnRemove(row)">  <span class="glyphicon glyphicon-remove-circle"></span> </button>  <button type="button" class="btn btn-default" ng-click="grid.appScope.btnUpdate(row)"> <span class="glyphicon glyphicon-pencil"></span></button>' }],
                    get: Produto.query,
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



