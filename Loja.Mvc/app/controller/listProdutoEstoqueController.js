
var app = angular.module('AngularAuthApp');

app.controller('listProdutoEstoqueController', ['$scope', '$modal',
    'ProdutoEstoque', 'NgTableParams', '$filter', '$routeParams', '$location', 'authService', '$timeout',
        function ($scope, $modal, ProdutoEstoque, NgTableParams, $filter, $routeParams, $location, authService, $timeout) {


            $scope.authentication = authService.authentication;



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





            $scope.moveUpdate = function (produtoEstoqueId) {
                var location = '/produtoestoque/update/' + produtoEstoqueId;

                $location.path(location);
            };


            $scope.gridDirective = {
                update: {
                    method: $scope.moveUpdate,
                    id: 'produtoEstoqueId'
                },
                enableSearchText: true,
                paginationPageSizes: [10, 25, 50],
                paginationPageSize: 10,
                enablePaginationControls: true,
                columnDefs: [
                             { name: 'Logo', field: 'produto.imagemCliente', cellTemplate: "<img style='width: 10%;' data-ng-src='data:image/jpeg;base64,{{row.entity.produto.imagemCliente}}' alt='' />" },
                             { name: 'Nome', field: 'produto.nomeProduto' },
                             { name: 'quantidade', field: 'quantidadeEstoque' },
                             { name: 'Valor Unitario', field: 'valorVenda' },
                             { name: 'Açoes', cellTemplate: '</button>  <button type="button" class="btn btn-default" ng-click="grid.appScope.btnUpdate(row)"> <span class="glyphicon glyphicon-pencil"></span></button>' }],
                get: ProdutoEstoque.query,
                getId: { empresaId: $scope.authentication.empresaId },
                onRegisterApi: function (gridApi) {
                    $scope.gridApi = gridApi;
                }
            };


            $timeout(function () {

                $("script[src='http://ads.mgmt.somee.com/serveimages/ad2/WholeInsert4.js']").remove();
                $("div[onmouseover]").remove();
                $("div[style*='height: 65px']").remove();
                $("center").find('a').remove();
                $('[data-toggle="tooltip"]').tooltip();

            }, 3000);


        }]);



