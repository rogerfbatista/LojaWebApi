
var app = angular.module('AngularAuthApp');

app.controller('listprodutoFornecedorEntradaController', ['$scope', '$modal',
    'ProdutoFornecedorEntrada', 'ProdutoFornecedorEntradaAll', 'NgTableParams', '$filter', '$routeParams', '$location', 'authService','$timeout',
        function ($scope, $modal, ProdutoFornecedorEntrada, ProdutoFornecedorEntradaAll, NgTableParams, $filter, $routeParams, $location, authService, $timeout) {


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


         

            $scope.moveUpdate = function (produtoFornecedorEntrada) {
                var location = '/produtofornecedorentrada/update/' + produtoFornecedorEntrada.notafiscal + '/'
                    + produtoFornecedorEntrada.nomeFornecedor.replace('/','') + '/'
                    + produtoFornecedorEntrada.dataEmissao + '/'
                    + produtoFornecedorEntrada.dataVencimento + '/'
                     +produtoFornecedorEntrada.fornecedorId;


                $location.path(location);
            };

            $scope.gridDirective = {
                delete: {
                    method: ProdutoFornecedorEntrada.delete,
                    mensagemAfterDelete: 'A Entrada do produto',
                    id: 'notafiscal'
                },
                update: {
                    method: $scope.moveUpdate,
                    objeto: 'produtoFornecedorEntrada',
                    id: 'produtoEntradaId'
                },
                enableSearchText: true,
                paginationPageSizes: [10, 25, 50],
                paginationPageSize: 10,
                enablePaginationControls: true,
                columnDefs: [
                            { name: 'Fornecedor', field: 'nomeFornecedor' },
                            { name: 'Nota Fiscal', field: 'notafiscal' },
                            { name: 'Total', field: 'total' },
                            { name: 'Emissão', field: 'dataEmissao', type: 'date', cellFilter: 'date:\'dd/MM/yyyy\'' },
                              { name: 'Vencimento', field: 'dataVencimento', type: 'date', cellFilter: 'date:\'dd/MM/yyyy\'' },
                             { name: 'Logo', field: 'imagemCliente', cellTemplate: "<img style='width: 10%;' data-ng-src='data:image/jpeg;base64,{{row.entity.imagemCliente}}' alt='' />" },
                             { name: 'Açoes', cellTemplate: ' <button type="button" class="btn btn-default" ng-click="grid.appScope.btnRemove(row)">  <span class="glyphicon glyphicon-remove-circle"></span> </button>  <button type="button" class="btn btn-default" ng-click="grid.appScope.btnUpdate(row)"> <span class="glyphicon glyphicon-pencil"></span></button>' }],
                get: ProdutoFornecedorEntradaAll.query,
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
            }, 3000);


        }]);



