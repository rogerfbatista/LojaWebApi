
var app = angular.module('AngularAuthApp');

app.controller('updateprodutoClienteSaidaController', ['$scope', '$q', '$timeout', '$sce', '$modal',
    'ProdutoClienteSaida', '$routeParams', '$location', 'authService', '$timeout',
function ($scope, $q, $timeout, $sce, $modal, ProdutoClienteSaida, $routeParams, $location, authService, $timeout) {



    $scope.authentication = authService.authentication;



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


    

    ProdutoClienteSaida.get({ numeroPedido: $routeParams.id, empresaId: $scope.authentication.empresaId }).$promise.then(function (response) {

        $scope.produtoClienteSaida = response;

        for (var i = 0; i < $scope.produtoClienteSaida.produtoClienteSaidaItems.length; i++) {

            $scope.produtoClienteSaida.produtoClienteSaidaItems[i].valorUnitario = $scope.produtoClienteSaida.produtoClienteSaidaItems[i].subTotal / $scope.produtoClienteSaida.produtoClienteSaidaItems[i].quantidadeSaida;
        }

    },
        function (error) {
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
    }, 3000);

}]);



