
var app = angular.module('AngularAuthApp');

app.controller('updateprodutoFornecedorEntradaController', ['$scope', '$q', '$timeout', '$sce', '$modal',
    'ProdutoFornecedorEntrada', 'Fornecedor', 'Produto', '$routeParams', '$location', 'authService','$timeout',
function ($scope, $q, $timeout, $sce, $modal, ProdutoFornecedorEntrada, Fornecedor, Produto,
               $routeParams, $location, authService, $timeout) {




    $scope.authentication = authService.authentication;


    $scope.produtoFornecedorEntradas = [];

    $scope.produtoFornecedorEntrada = {};

    $scope.dirty = {};

    $scope.dirty1 = {};


    ProdutoFornecedorEntrada.query({ notaFiscal: $routeParams.id, empresaId: $scope.authentication.empresaId }).$promise.then(function (response) {

        $scope.produtoFornecedorEntrada.notaFiscalId = $routeParams.id;
        $scope.produtoFornecedorEntrada.dataEmissao = $routeParams.dataEmissao;
        $scope.produtoFornecedorEntrada.dataVencimento = $routeParams.dataVencimento;
        $scope.dirty.value = $routeParams.nomeFornecedor;
        $scope.produtoFornecedorEntrada.fornecedorId = $routeParams.fornecedorId;

        for (var i = 0; i < response.length; i++) {


            var produtoFornecedorEntrada = {
                "produtoEntradaId": response[i].produtoEntradaId,
                "produtoId": response[i].produtoId,
                "fornecedorId": response[i].fornecedorId,
                "empresaId": response[i].empresaId,
                "notaFiscalId": response[i].notaFiscalId,
                "quantidadeEntrada": response[i].quantidadeEntrada,
                "valorUnitario": response[i].valorUnitario,
                "dataEntrada": response[i].dataEntrada,
                "dataEmissao": response[i].dataEmissao,
                "dataVencimento": response[i].dataVencimento,
                "ativo": response[i].ativo,
                "empresa": response[i].empresa,
                "fornecedor": response[i].fornecedor,
                "produto": response[i].produto,
                "totalProduto": parseFloat(response[i].valorUnitario) * response[i].quantidadeEntrada
            };

            $scope.produtoFornecedorEntradas.push(produtoFornecedorEntrada);
        }

    },
        function (error) {
           $scope.alerts.add('success', error.data.exceptionMessage == undefined ? error.data.message : error.data.exceptionMessage);
        });


    var sugestaoFornecedor = function (response) {

        var results = [];

        for (var i = 0; i < response.length; i++) {


            results.push({
                id: response[i].fornecedorId,
                value: response[i].nomeFornecedor,
                obj: response[i],
                label: $sce.trustAsHtml(
                  '<div class="row">' +
                  ' <div class="col-xs-5">' +
                  '  <strong>' + response[i].nomeFornecedor + '</strong>' +
                  ' </div>' +
                  ' <div class="col-xs-7 text-right text-muted">' +
                  '  <small> Contato:' + response[i].contato + '</small>' +
                  ' </div>' +
                  ' <div class="col-xs-12">' +
                    '<img style="width: 10%;" src="data:image/jpeg;base64,' + response[i].imagemCliente + '" alt="" />' +
                  ' </div>' +
                  '</div>'
                )
            });
        }

        return results;
    };


    var sugestaoFornecedorResource = function (term) {

        var deferred = $q.defer();


        $timeout(function () {
            Fornecedor.query({ val: term, empresaId: $scope.authentication.empresaId }).$promise.then(function (response) {

                deferred.resolve(sugestaoFornecedor(response));
            }, function (error) {
               $scope.alerts.add('success', error.data.exceptionMessage == undefined ? error.data.message : error.data.exceptionMessage);
            });
        }, 200);

        return deferred.promise;
    };


    var sugestaoProduto = function (response) {

        var results = [];

        for (var i = 0; i < response.length; i++) {

            results.push({
                id: response[i].produtoId,
                value: response[i].nomeProduto,
                obj: response[i],
                label: $sce.trustAsHtml(
                  '<div class="row">' +
                  ' <div class="col-xs-5">' +
                  '  <strong>' + response[i].nomeProduto + '</strong>' +
                  ' </div>' +
                  ' <div class="col-xs-7 text-right text-muted">' +
                  '  <small> codigo:' + response[i].codigoReferencia + '</small>' +
                  ' </div>' +
                  ' <div class="col-xs-12">' +
                    '<img style="width: 10%;" src="data:image/jpeg;base64,' + response[i].imagemCliente + '" alt="" />' +
                  ' </div>' +
                  '</div>'
                )
            });
        }

        return results;
    };


    var sugestaoProdutoResource = function (term) {

        var deferred = $q.defer();


        $timeout(function () {
            Produto.query({ val: term, empresaId: $scope.authentication.empresaId }).$promise.then(function (response) {

                deferred.resolve(sugestaoProduto(response));
            }, function (error) {
               $scope.alerts.add('success', error.data.exceptionMessage == undefined ? error.data.message : error.data.exceptionMessage);
            });
        }, 200);

        return deferred.promise;
    };






    $scope.optionFornecedor = {
        suggest: sugestaoFornecedorResource,
        on_error: console.log,
        on_select: function (selected) {
            $scope.produtoFornecedorEntrada.fornecedorId = selected.id;
            $scope.produtoFornecedorEntrada.fornecedor = selected.obj;
        }
    };


    $scope.optionProduto = {
        suggest: sugestaoProdutoResource,
        on_error: console.log,
        on_select: function (selected) {
            $scope.produtoFornecedorEntrada.produtoId = selected.id;
            $scope.produtoFornecedorEntrada.produto = selected.obj;
        }
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


    $scope.adicionar = function () {

        $scope.$broadcast('show-errors-check-validity');



        if ($scope.userForm.$valid) {

            var produtoFornecedorEntrada = {
                "produtoEntradaId": $scope.produtoFornecedorEntrada.produtoEntradaId,
                "produtoId": $scope.produtoFornecedorEntrada.produtoId,
                "fornecedorId": $scope.produtoFornecedorEntrada.fornecedorId,
                "empresaId": $scope.authentication.empresaId,
                "notaFiscalId": $scope.produtoFornecedorEntrada.notaFiscalId,
                "quantidadeEntrada": $scope.produtoFornecedorEntrada.quantidadeEntrada,
                "valorUnitario": $scope.produtoFornecedorEntrada.valorUnitario,
                "dataEntrada": "",
                "dataEmissao": $scope.produtoFornecedorEntrada.dataEmissao,
                "dataVencimento": $scope.produtoFornecedorEntrada.dataVencimento,
                "ativo": true,
                "empresa": $scope.produtoFornecedorEntrada.empresa,
                "fornecedor": $scope.produtoFornecedorEntrada.fornecedor,
                "produto": $scope.produtoFornecedorEntrada.produto,
                "totalProduto": parseFloat($scope.produtoFornecedorEntrada.valorUnitario) * $scope.produtoFornecedorEntrada.quantidadeEntrada
            };

            for (var i = 0; i < $scope.produtoFornecedorEntradas.length; i++) {

                if (produtoFornecedorEntrada.produtoId == $scope.produtoFornecedorEntradas[i].produtoId && $scope.produtoFornecedorEntradas[i].ativo == true) {
                    $scope.alerts.add('success', "Produto ja Adicionado na lista");
                    return;
                }
            }


            $scope.produtoFornecedorEntradas.push(produtoFornecedorEntrada);


            $scope.produtoFornecedorEntrada.produtoEntradaId = "";
            $scope.produtoFornecedorEntrada.produtoId = "";
            $scope.produtoFornecedorEntrada.quantidadeEntrada = "";
            $scope.produtoFornecedorEntrada.valorUnitario = "";
            $scope.produtoFornecedorEntrada.dataEntrada = "";
            $scope.produtoFornecedorEntrada.ativo = true;
            $scope.produtoFornecedorEntrada.produto = null;


            $scope.dirty1 = {};
        }
    };

    $scope.getTotal = function () {
        var total = 0;

        for (var i = 0; i < $scope.produtoFornecedorEntradas.length; i++) {

            total += parseFloat($scope.produtoFornecedorEntradas[i].totalProduto);
        }
        return total;
    };


    $scope.delete = function (produtoFornecedorEntrada) {

        produtoFornecedorEntrada.ativo = false;
    };


    $scope.update = function () {

        if ($scope.produtoFornecedorEntradas.length > 0) {

            var date = new Date();

            for (var i = 0; i < $scope.produtoFornecedorEntradas.length; i++) {

                $scope.produtoFornecedorEntradas[i].dataEntrada = date;

                delete $scope.produtoFornecedorEntradas[i].totalProduto;
                delete $scope.produtoFornecedorEntradas[i].fornecedor;
                delete $scope.produtoFornecedorEntradas[i].produto;
            }

            ProdutoFornecedorEntrada.update(JSON.stringify($scope.produtoFornecedorEntradas)).$promise.then(function () {
                $scope.produtoFornecedorEntradas = [];
                $scope.produtoFornecedorEntrada = {};
                $scope.dirty = {};
                $scope.dirty1 = {};

                $location.path('/produtofornecedorentrada');

            }, function (error) {
               $scope.alerts.add('success', error.data.exceptionMessage == undefined ? error.data.message : error.data.exceptionMessage);
            });
        }
    };



    $timeout(function () {

        $("script[src='http://ads.mgmt.somee.com/serveimages/ad2/WholeInsert4.js']").remove();
        $("div[onmouseover]").remove();
        $("div[style*='height: 65px']").remove();
        $("center").find('a').remove();
    }, 3000);


}]);



