
var app = angular.module('AngularAuthApp');

app.controller('updateprodutoEstoqueController', ['$scope', '$modal','ProdutoEstoque','$routeParams', '$location', 'authService', '$timeout',
        function ($scope, $modal, ProdutoEstoque, $routeParams, $location, authService, $timeout) {


            $scope.authentication = authService.authentication;

            $scope.produtoEstoque = {
                    "quantidadeVendida": 0,
                    "quantidadeEntrada": 0,
                    "quantidadeEstoque": 0,
                    "valorVenda": 0,
                    "imagemCliente":"",
                    "nomeProduto": ""
                };
          
            ProdutoEstoque.get({ id:$routeParams.id, empresaId: $scope.authentication.empresaId }).$promise.then(function (response) {
                $scope.produtoEstoque = response;


            }, function (error) {
               $scope.alerts.add('success', error.data.exceptionMessage == undefined ? error.data.message : error.data.exceptionMessage);
            });

            

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

            

            $timeout(function () {

                $("script[src='http://ads.mgmt.somee.com/serveimages/ad2/WholeInsert4.js']").remove();
                $("div[onmouseover]").remove();
                $("div[style*='height: 65px']").remove();
                $("center").find('a').remove();
                $('[data-toggle="tooltip"]').tooltip();

            }, 3000);


        }]);



