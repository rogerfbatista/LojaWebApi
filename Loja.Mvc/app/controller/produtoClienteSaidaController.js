
var app = angular.module('AngularAuthApp');

app.controller('ProdutoClienteSaidaController', ['$scope', '$q', '$timeout', '$sce', '$modal',
    'ProdutoClienteSaida', 'Cliente', 'ProdutoEstoque', 'ProdutoFormasDePagamento', '$routeParams', '$location', 'authService',
function ($scope, $q, $timeout, $sce, $modal, ProdutoClienteSaida, Cliente, ProdutoEstoque, ProdutoFormasDePagamento,
               $routeParams, $location, authService) {




    $scope.authentication = authService.authentication;

    $scope.produtoFormasDePagamento = [];


    $scope.produto = {};

    $scope.cliente = {};

    $scope.produtoClienteSaida = {

        "produtoClienteSaidaId": 0,
        "empresaId": $scope.authentication.empresaId,
        "clienteId": 0,
        "produtoFormasDePagamentoId": 0,
        "valorTotal": 0,
        "dataVenda": "",
        "ativo": true,
        "cliente": {},
        "empresa": {},
        "produtoFormasDePagamento": {},
        "produtoClienteSaidaItems": []
    };

    $scope.dirty = {};

    $scope.dirty1 = {};

    $scope.produtoEstoque = {};



    var sugestaoCliente = function (response) {

        var results = [];

        for (var i = 0; i < response.length; i++) {


            results.push({
                value: response[i].nomeCliente,
                obj: response[i],
                label: $sce.trustAsHtml(
                  '<div class="row">' +
                  ' <div class="col-xs-5">' +
                  '  <strong>' + response[i].nomeCliente + '</strong>' +
                  ' </div>' +
                  ' <div class="col-xs-7 text-right text-muted">' +
                  '  <small> CPF-CNPJ:' + response[i].cpfCnpj + '</small>' +
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


    var sugestaoClienteResource = function (term) {

        var deferred = $q.defer();


        $timeout(function () {
            Cliente.query({ val: term, empresaId: $scope.authentication.empresaId }).$promise.then(function (response) {

                deferred.resolve(sugestaoCliente(response));
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

                value: response[i].produto.nomeProduto,
                obj: response[i],
                label: $sce.trustAsHtml(
                  '<div class="row">' +
                  ' <div class="col-xs-5">' +
                  '  <strong>' + response[i].produto.nomeProduto + '</strong>' +
                  ' </div>' +
                  ' <div class="col-xs-7 text-right text-muted">' +
                  '  <small> codigo:' + response[i].produto.codigoReferencia + '</small>' +
                   '  <small> Quant Estoque:' + response[i].quantidadeEstoque + '</small>' +
                      '  <small>valor:' + response[i].valorVenda + '</small>' +
                  ' </div>' +
                  ' <div class="col-xs-12">' +
                    '<img style="width: 10%;" src="data:image/jpeg;base64,' + response[i].produto.imagemCliente + '" alt="" />' +
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
            ProdutoEstoque.query({ val: term, empresaId: $scope.authentication.empresaId }).$promise.then(function (response) {

                deferred.resolve(sugestaoProduto(response));
            }, function (error) {
               $scope.alerts.add('success', error.data.exceptionMessage == undefined ? error.data.message : error.data.exceptionMessage);
            });
        }, 200);

        return deferred.promise;
    };


    $scope.optionCliente = {
        suggest: sugestaoClienteResource,
        on_error: console.log,
        on_select: function (selected) {
            $scope.cliente = selected.obj;
        }
    };


    $scope.optionProduto = {
        suggest: sugestaoProdutoResource,
        on_error: console.log,
        on_select: function (selected) {
            $scope.produtoEstoque = selected.obj;
            $scope.produto = selected.obj.produto;
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

    $scope.getTotalProduto = function () {

        return $scope.produtoEstoque.valorVenda * parseInt($scope.quantidadeSaida);
    };


    $scope.adicionar = function () {

        $scope.$broadcast('show-errors-check-validity');

        if ($scope.userForm.$valid) {



            var produtoClienteSaidaItem = {
                "produtoClienteSaidaItemId": 0,
                "produtoClienteSaidaId": 0,
                "produtoId": $scope.produto.produtoId,
                "quantidadeSaida": $scope.quantidadeSaida,
                "subTotal": $scope.produtoEstoque.valorVenda * $scope.quantidadeSaida,
                "ativo": true,
                "cliente": {},
                "empresa": {},
                "produto": $scope.produto,
                "produtoClienteSaida": {},
                "valorUnitario": ($scope.produtoEstoque.valorVenda * $scope.quantidadeSaida) / $scope.quantidadeSaida

            };

            for (var i = 0; i < $scope.produtoClienteSaida.produtoClienteSaidaItems.length; i++) {

                if ($scope.produtoClienteSaida.produtoClienteSaidaItems[i].produtoId == $scope.produto.produtoId) {
                    $scope.alerts.add('success', "Produto já Adicionado");
                    return;
                }
            }

            $scope.produtoClienteSaida.produtoClienteSaidaItems.push(produtoClienteSaidaItem);

            if ($scope.produtoFormasDePagamento.length == 0) {
                ProdutoFormasDePagamento.query().$promise.then(function (response) {
                    $scope.produtoFormasDePagamento = response;
                    $scope.produtoClienteSaida.produtoFormasDePagamentoId = 1;
                }, function (error) {
                   $scope.alerts.add('success', error.data.exceptionMessage == undefined ? error.data.message : error.data.exceptionMessage);
                });
            }

            $scope.produto = {};
            $scope.produtoEstoque = {};
            $scope.quantidadeSaida = "";
            $scope.dirty1 = {};
        }
    };

    $scope.getTotal = function () {
        var total = 0;

        for (var i = 0; i < $scope.produtoClienteSaida.produtoClienteSaidaItems.length; i++) {

            total += parseFloat($scope.produtoClienteSaida.produtoClienteSaidaItems[i].subTotal);

            $scope.produtoClienteSaida.valorTotal = total;
        }
        return total;
    };


    $scope.delete = function (produtoClienteSaida) {
        var index = $scope.produtoClienteSaida.produtoClienteSaidaItems.indexOf(produtoClienteSaida);
        $scope.produtoClienteSaida.produtoClienteSaidaItems.splice(index, 1);

    };


    $scope.save = function () {

        $scope.$broadcast('show-errors-check-validity');

        if ($scope.userFormPagamento.$valid && $scope.produtoClienteSaida.produtoClienteSaidaItems.length > 0 && $scope.produtoClienteSaida.produtoFormasDePagamentoId > 0) {

            var date = new Date();

            for (var i = 0; i < $scope.produtoClienteSaida.produtoClienteSaidaItems.length; i++) {

                $scope.produtoClienteSaida.dataVenda = date;
                $scope.produtoClienteSaida.produtoFormasDePagamentoId = $scope.produtoClienteSaida.produtoFormasDePagamentoId;
                $scope.produtoClienteSaida.clienteId = $scope.cliente.clienteId;


                delete $scope.produtoClienteSaida.cliente;

                delete $scope.produtoClienteSaida.produtoClienteSaidaItems[i].produtoClienteSaida;
                delete $scope.produtoClienteSaida.produtoClienteSaidaItems[i].cliente;
                delete $scope.produtoClienteSaida.produtoClienteSaidaItems[i].produto;
                delete $scope.produtoClienteSaida.empresa;
                delete $scope.produtoClienteSaida.produtoFormasDePagamento;
            }

            ProdutoClienteSaida.save(JSON.stringify($scope.produtoClienteSaida)).$promise.then(function () {

                $scope.produtoClienteSaida = {};
                $scope.dirty = {};
                $scope.dirty1 = {};
                $scope.produtoEstoque = {};
                $scope.produto = {};
                $scope.cliente = {};
                $location.path('/produtoclientesaida');

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



