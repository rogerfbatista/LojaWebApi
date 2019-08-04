
var app = angular.module('AngularAuthApp');

app.controller('clienteController', ['$scope', '$modal', 'Cliente', 'ClienteAll', 'NgTableParams', '$filter',
                '$routeParams', '$location', 'authService', '$timeout',
        function ($scope, $modal, Cliente, ClienteAll, NgTableParams, $filter, $routeParams, $location, authService, $timeout) {


            $scope.authentication = authService.authentication;

            $scope.cabecalho = 'Cadastro de ';
            $scope.btn = 'Adicionar';

            $scope.cliente = {
                "clienteId": 0,
                "nomeCliente": "",
                "cpfCnpj": "",
                "imagemCliente": null,
                "ativo": true,
                "clienteContatos": [],
                "empresaClientes": [
                {
                    'EmpresaClienteId': 0,
                    'ClienteId': 0,
                    'EmpresaId': $scope.authentication.empresaId,
                    'Ativo': true,

                }],
                "produtoClienteSaida": []
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

                    Cliente.save(JSON.stringify($scope.cliente), function () {
                        $location.path('/cliente');
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
                    Cliente.update(JSON.stringify($scope.cliente), function () {
                        $location.path('/cliente');

                    },
                    function (error) {

                        $scope.alerts.add('success', error.data.exceptionMessage == undefined ? error.data.message : error.data.exceptionMessage);
                    });
                }
            };

            if ($location.path().indexOf('update') > 0) {
                $scope.cabecalho = 'Alterar ';
                $scope.btn = 'Alterar';

                Cliente.get({ id: $routeParams.id }).$promise.then(function (response) {
                    $scope.cliente = response;

                }, function (error) {

                    $scope.alerts.add('success', error.data.exceptionMessage == undefined ? error.data.message : error.data.exceptionMessage);
                });


            };

            $scope.moveUpdate = function (id) {

                var location = '/cliente/update/' + id;


                $location.path(location);
            };



            $scope.salvar = function () {

                $timeout(function () {
                    if ($scope.cliente.clienteId > 0)
                        $scope.update();
                    else
                        $scope.save();
                });
            };


            $scope.AdicionarContato = function () {


                if ($scope.userFormContato.$valid) {
                    var clienteContato = {
                        'clienteContatoId': $scope.cliente.clienteContatos.length + 1,
                        'empresaId': 0,
                        'email': $scope.email,
                        'telefone': $scope.telefone,
                        'ativo': true,
                        'empresa': null
                    };
                    $scope.email = "";
                    $scope.telefone = "";

                    $scope.cliente.clienteContatos.push(clienteContato);

                }
            };

            $scope.AdicionarContatoUpdate = function () {

                var clienteContato = {
                    'clienteContatoId': 0,
                    'clienteId': $scope.cliente.clienteId,
                    'email': $scope.email,
                    'telefone': $scope.telefone,
                    'ativo': true,
                    'fornecedor': null
                };

                $scope.email = "";
                $scope.telefone = "";
                $scope.cliente.clienteContatos.push(clienteContato);
            };

            $scope.deleteContato = function (clienteContato) {
                var index = $scope.cliente.clienteContatos.indexOf(clienteContato);
                $scope.cliente.clienteContatos.splice(index, 1);

            };


            $scope.deleteContatoUpdate = function (clienteContato) {

                clienteContato.ativo = false;


            };

            if ($location.path() == "/cliente") {


                $scope.gridDirective = {
                    delete: {
                        method: Cliente.delete,
                        mensagemAfterDelete: 'O Cliente',
                        id: 'clienteId'
                    },
                    update: {
                        method: $scope.moveUpdate,
                        id: 'clienteId'
                    },
                    enableSearchText: true,
                    paginationPageSizes: [10, 25, 50],
                    paginationPageSize: 10,
                    enablePaginationControls: true,
                    columnDefs: [
                                { name: 'Nome', field: 'nomeCliente' },
                                 { name: 'cpf -Cnpj', field: 'cpfCnpj' },
                                 { name: 'Logo', field: 'imagemCliente', cellTemplate: "<img style='width: 10%;' data-ng-src='data:image/jpeg;base64,{{row.entity.imagemCliente}}' alt='' />" },
                                 { name: 'Açoes', cellTemplate: ' <button type="button" class="btn btn-default" ng-click="grid.appScope.btnRemove(row)">  <span class="glyphicon glyphicon-remove-circle"></span> </button>  <button type="button" class="btn btn-default" ng-click="grid.appScope.btnUpdate(row)"> <span class="glyphicon glyphicon-pencil"></span></button>' }],
                    get: Cliente.query,
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



