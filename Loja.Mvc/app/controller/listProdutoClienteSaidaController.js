
var app = angular.module('AngularAuthApp');




app.controller('listprodutoClienteSaidaController', [
          '$scope', '$modal', 'ProdutoClienteSaida', 'ProdutoClienteSaidaAll', 'ProdutoClienteSaidaPagination', 'NgTableParams', '$filter', '$routeParams', '$location', 'authService', '$timeout',
function ($scope, $modal, ProdutoClienteSaida, ProdutoClienteSaidaAll, ProdutoClienteSaidaPagination, NgTableParams, $filter, $routeParams, $location, authService, $timeout) {


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


    $scope.moveUpdate = function (produtoClienteSaidaId) {
        var location = '/produtoclientesaida/update/' + produtoClienteSaidaId;
        $location.path(location);
    };


    $scope.gridDirective = {
        delete: {
            method: ProdutoClienteSaida.delete,
            mensagemAfterDelete: 'Pedido ',
            id: 'produtoClienteSaidaId'
        },
        update: {
            method: $scope.moveUpdate,
            id: 'produtoClienteSaidaId'
        },
        enableSearchText: true,
        paginationPageSizes: [10, 25, 50],
        paginationPageSize: 10,
        enablePaginationControls: true,
        useExternalPagination: true,
        columnDefs: [
            { name: 'Numero Pedido', field: 'produtoClienteSaidaId' },
            { name: 'Total', field: 'valorTotal', type: 'number', cellFilter: 'currencyFilter' },
            { name: 'Data pedido', field: 'dataVenda', type: 'date', cellFilter: 'date:\'dd/MM/yyyy\'' },
            { name: 'Cliente', field: 'nomeCliente' },
            { name: 'ImagemCliente', field: 'imagemCliente', cellTemplate: "<img style='width: 15%;' class='img-responsive ' data-ng-src='data:image/jpeg;base64,{{row.entity.imagemCliente}}' alt='' />{{row.entity.nomeCliente}}" },
            { name: 'Açoes', cellTemplate: ' <button type="button" class="btn btn-default" ng-click="grid.appScope.btnRemove(row)">  <span class="glyphicon glyphicon-remove-circle"></span> </button>  <button type="button" class="btn btn-default" ng-click="grid.appScope.btnUpdate(row)"> <span class="glyphicon glyphicon-pencil"></span></button>' }
        ],
        get: ProdutoClienteSaidaPagination.query,
        getSerachText: ProdutoClienteSaidaAll.query,
        empresaId: $scope.authentication.empresaId
    };

    $timeout(function () {

        $("script[src='http://ads.mgmt.somee.com/serveimages/ad2/WholeInsert4.js']").remove();
        $("div[onmouseover]").remove();
        $("div[style*='height: 65px']").remove();
        $("center").find('a').remove();
    }, 3000);

}]);
