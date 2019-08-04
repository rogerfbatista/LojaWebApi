
var app = angular.module('AngularAuthApp');

app.controller('fornecedorController', ['$scope', '$modal', 'Fornecedor', 'FornecedorAll', 'NgTableParams', '$filter',
                '$routeParams', '$location', 'authService', '$timeout',
        function ($scope, $modal, Fornecedor, FornecedorAll, NgTableParams, $filter, $routeParams, $location, authService, $timeout) {


            $scope.cabecalho = 'Cadastro de ';
            $scope.btn = 'Adicionar';
            $scope.btnEnable = false;

            $scope.authentication = authService.authentication;


            $scope.fornecedor = {

                "fornecedorId": 0,
                "nomeFornecedor": "",
                "contato": "",
                "cnpj": "",
                "inscricaoEstadual": "",
                "endereco": "",
                "numero": "",
                "estado": "",
                "cidade": "",
                "imagemCliente": null,
                "ativo": true,
                "empresaFornecedores": [
                {
                    'EmpresaFornecedorId': 0,
                    'FornecedorId': 0,
                    'EmpresaId': $scope.authentication.empresaId,
                    'Ativo': true
                }],
                "fornecedorContatos": [],
                "produtoFornecedorEntradas": []
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
                    $scope.btnEnable = true;
                    Fornecedor.save(JSON.stringify($scope.fornecedor), function () {
                        $scope.btnEnable = false;
                        $location.path('/fornecedor');
                    },
                    function (error) {
                        $scope.btnEnable = false;
                        $scope.alerts.add('success', error.data.exceptionMessage == undefined ? error.data.message : error.data.exceptionMessage);
                    });
                }

            };

            //alterar
            $scope.update = function () {

                $scope.$broadcast('show-errors-check-validity');

                if ($scope.userForm.$valid) {
                    $scope.btnEnable = true;
                    Fornecedor.update(JSON.stringify($scope.fornecedor), function () {
                        $location.path('/fornecedor');
                        $scope.btnEnable = false;
                    },
                    function (error) {
                        $scope.btnEnable = false;
                        $scope.alerts.add('success', error.data.exceptionMessage == undefined ? error.data.message : error.data.exceptionMessage);
                    });
                }
            };

            if ($location.path().indexOf('update') > 0) {

                $scope.cabecalho = 'Alterar ';
                $scope.btn = 'Alterar';

                Fornecedor.get({ id: $routeParams.id }).$promise.then(function (response) {
                    $scope.fornecedor = response;

                }, function (error) {

                    $scope.alerts.add('success', error.data.exceptionMessage == undefined ? error.data.message : error.data.exceptionMessage);
                });


            };

            $scope.moveUpdate = function (id) {

                var location = '/fornecedor/update/' + id;


                $location.path(location);
            };

            $scope.salvar = function () {

                $timeout(function () {
                    if ($scope.fornecedor.fornecedorId > 0)
                        $scope.update();
                    else
                        $scope.save();
                });
            };



            $scope.AdicionarContato = function () {


                if ($scope.userFormContato.$valid) {
                    var empresaContato = {
                        'empresaContatoId': $scope.fornecedor.fornecedorContatos.length + 1,
                        'empresaId': 0,
                        'email': $scope.email,
                        'telefone': $scope.telefone,
                        'ativo': true,
                        'empresa': null
                    };
                    $scope.email = "";
                    $scope.telefone = "";
                    $scope.fornecedor.fornecedorContatos.push(empresaContato);

                }
            };

            $scope.AdicionarContatoUpdate = function () {

                var fornecedorContato = {
                    'fornecedorContatoId': 0,
                    'fornecedorId': $scope.fornecedor.fornecedorId,
                    'email': $scope.email,
                    'telefone': $scope.telefone,
                    'ativo': true,
                    'fornecedor': null
                };

                $scope.email = "";
                $scope.telefone = "";
                $scope.fornecedor.fornecedorContatos.push(fornecedorContato);
            };

            $scope.deleteContato = function (fornecedorContato) {
                var index = $scope.fornecedor.fornecedorContatos.indexOf(fornecedorContato);
                $scope.fornecedor.fornecedorContatos.splice(index, 1);

            };


            $scope.deleteContatoUpdate = function (fornecedorContato) {

                fornecedorContato.ativo = false;


            };

            if ($location.path() == "/fornecedor") {

                $scope.gridDirective = {
                    delete: {
                        method: Fornecedor.delete,
                        mensagemAfterDelete: 'O Fornecedor',
                        id: 'fornecedorId'
                    },
                    update: {
                        method: $scope.moveUpdate,
                        id: 'fornecedorId'
                    },
                    enableSearchText: true,
                    paginationPageSizes: [10, 25, 50],
                    paginationPageSize: 10,
                    enablePaginationControls: true,
                    columnDefs: [
                                { name: 'Nome', field: 'nomeFornecedor' },
                                { name: 'contato', field: 'contato' },
                                 { name: 'Logo', field: 'empresaImagem', cellTemplate: "<img style='width: 10%;' data-ng-src='data:image/jpeg;base64,{{row.entity.imagemCliente}}' alt='' />" },
                                 { name: 'Açoes', cellTemplate: ' <button type="button" class="btn btn-default" ng-click="grid.appScope.btnRemove(row)">  <span class="glyphicon glyphicon-remove-circle"></span> </button>  <button type="button" class="btn btn-default" ng-click="grid.appScope.btnUpdate(row)"> <span class="glyphicon glyphicon-pencil"></span></button>' }],
                    get: Fornecedor.query,
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



