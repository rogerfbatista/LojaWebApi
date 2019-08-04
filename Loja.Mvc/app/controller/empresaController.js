
var app = angular.module('AngularAuthApp');

app.controller('empresaController', ['$scope', '$modal', 'Empresa', 'NgTableParams', '$filter',
                '$routeParams', '$location', '$rootScope', '$timeout',
        function ($scope, $modal, Empresa, NgTableParams, $filter, $routeParams, $location, $rootScope, $timeout) {


            $scope.cabecalho = 'Cadastro de ';
            $scope.btn = 'Adicionar';


            $scope.empresa = {
                'empresaId': 0,
                "nomeEmpresa": "",
                "nomeFantasia": "",
                "contato": "",
                "inscricaoEstadual": "",
                "cnpj": "",
                "endereco": "",
                "numero": "",
                "estado": "",
                "cidade": "",
                "empresaImagem": "",
                "ativo": true,
                "empresaContatos": []
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
                    Empresa.save(JSON.stringify($scope.empresa), function () {
                        $location.path('/empresa');
                    });
                }

            };

            //alterar
            $scope.update = function () {

                $scope.$broadcast('show-errors-check-validity');

                if ($scope.userForm.$valid) {
                    Empresa.update(JSON.stringify($scope.empresa), function () {
                        $location.path('/empresa');

                    });
                }
            };

            if ($location.path().indexOf('update') > 0) {

                $scope.cabecalho = 'Alterar ';
                $scope.btn = 'Alterar';

                Empresa.get({ id: $routeParams.id }).$promise.then(function (response) {
                    $scope.empresa = response;

                });


            };

            $scope.moveUpdate = function (id) {
                var location = '/empresa/update/' + id;
                $location.path(location);
            };

            $scope.salvar = function () {

                $timeout(function () {
                    if ($scope.empresa.empresaId > 0)
                        $scope.update();
                    else
                        $scope.save();
                });
            };

            $scope.AdicionarContato = function () {


                if ($scope.userFormContato.$valid) {
                    var empresaContato = {
                        'empresaContatoId': $scope.empresa.empresaContatos.length + 1,
                        'empresaId': 0,
                        'email': $scope.email,
                        'telefone': $scope.telefone,
                        'ativo': true,
                        'empresa': null
                    };
                    $scope.email = "";
                    $scope.telefone = "";
                    $scope.empresa.empresaContatos.push(empresaContato);

                }
            };

            $scope.AdicionarContatoUpdate = function () {

                var empresaContato = {
                    'empresaContatoId': 0,
                    'empresaId': $scope.empresa.empresaId,
                    'email': $scope.email,
                    'telefone': $scope.telefone,
                    'ativo': true,
                    'empresa': null
                };
                $scope.email = "";
                $scope.telefone = "";
                $scope.empresa.empresaContatos.push(empresaContato);
            };

            $scope.deleteContato = function (empresaContato) {
                var index = $scope.empresa.empresaContatos.indexOf(empresaContato);
                $scope.empresa.empresaContatos.splice(index, 1);

            };


            $scope.deleteContatoUpdate = function (empresaContato) {

                empresaContato.ativo = false;


            };


            if ($location.path() == "/empresa") {


                $scope.gridDirective = {
                    delete: {
                        method: Empresa.delete,
                        mensagemAfterDelete: 'A Empresa',
                        id: 'empresaId'
                    },
                    update: {
                        method: $scope.moveUpdate,
                        id: 'empresaId'
                    },
                    enableSearchText: true,
                    paginationPageSizes: [10, 25, 50],
                    paginationPageSize: 10,
                    enablePaginationControls: true,
                    columnDefs: [
                                { name: 'Nome', field: 'nomeEmpresa' },
                                 { name: 'Nome Fantasia', field: 'nomeFantasia' },
                                { name: 'contato', field: 'contato' },
                                 { name: 'Logo', field: 'empresaImagem', cellTemplate: "<img style='width: 10%;' data-ng-src='data:image/jpeg;base64,{{row.entity.empresaImagem}}' alt='' />" },
                                 { name: 'Açoes', cellTemplate: ' <button type="button" class="btn btn-default" ng-click="grid.appScope.btnRemove(row)">  <span class="glyphicon glyphicon-remove-circle"></span> </button>  <button type="button" class="btn btn-default" ng-click="grid.appScope.btnUpdate(row)"> <span class="glyphicon glyphicon-pencil"></span></button>' }],
                    get: Empresa.query,
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



