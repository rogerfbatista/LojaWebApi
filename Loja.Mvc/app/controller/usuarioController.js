
var app = angular.module('AngularAuthApp');

app.controller('usuarioController', [
    '$scope', '$modal', 'Usuario', 'UsuarioPerfil', 'NgTableParams', '$filter',
    '$routeParams', '$location', 'authService', '$timeout', '$linq',
    function ($scope, $modal, Usuario, UsuarioPerfil,
        NgTableParams, $filter, $routeParams, $location, authService, $timeout, $linq) {


        $scope.cabecalho = 'Cadastro de ';
        $scope.btn = 'Adicionar';

        $scope.authentication = authService.authentication;

        $scope.usuarioPerfil = [];

        $scope.usuario = {
            'usuarioId': 0,
            'usuarioPerfilId': 0,
            'empresaId': $scope.authentication.empresaId,
            'nomeUsuario': "",
            'email': "",
            'senha': "",
            'dataCadastro': "",
            'imagemUsuario': "",
            'ativo': true,
            'empresa': null,

        };




        $scope.getQuery = function () {

            UsuarioPerfil.query().$promise.then(function (result) {

                $scope.usuarioPerfil = result;

                if ($scope.usuario.usuarioPerfilId > 0) {

                    $scope.selected = $linq.Enumerable().From($scope.usuarioPerfil).Where(function (u) {
                        return u.usuarioPerfilId == $scope.usuario.usuarioPerfilId;
                    }).ToArray()[0];
                }
            }, function (error) {
                $scope.alerts.add('success', error.data.exceptionMessage == undefined ? error.data.message : error.data.exceptionMessage);
            });

        };

        if ($location.path().indexOf('new') > 0) {
            $scope.getQuery();

        }





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
                $scope.usuario.usuarioPerfilId = $scope.selected.usuarioPerfilId;
                Usuario.save(JSON.stringify($scope.usuario), function () {
                    $location.path('/usuario');
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
                $scope.usuario.usuarioPerfilId = $scope.selected.usuarioPerfilId;
                Usuario.update(JSON.stringify($scope.usuario), function () {
                    $location.path('/usuario');

                },
                    function (error) {

                        $scope.alerts.add('success', error.data.exceptionMessage == undefined ? error.data.message : error.data.exceptionMessage);
                    });
            }
        };

        if ($location.path().indexOf('update') > 0) {

            $scope.cabecalho = 'Alterar ';
            $scope.btn = 'Alterar';



            Usuario.get({ id: $routeParams.id }).$promise.then(function (response) {

                $scope.usuario = response;

                $scope.getQuery();

            }, function (error) {

                $scope.alerts.add('success', error.data.exceptionMessage == undefined ? error.data.message : error.data.exceptionMessage);
            });


        };

        $scope.moveUpdate = function (id) {

            var location = '/usuario/update/' + id;

            $location.path(location);
        };

        $scope.salvar = function () {

            $timeout(function () {
                if ($scope.usuario.usuarioId > 0)
                    $scope.update();
                else
                    $scope.save();
            });
        };

        if ($location.path() == "/usuario") {


            $scope.gridDirective = {
                delete: {
                    method: Usuario.delete,
                    mensagemAfterDelete: 'O Usuario',
                    id: 'usuarioId'
                },
                update: {
                    method: $scope.moveUpdate,
                    id: 'usuarioId'
                },
                enableSearchText: true,
                paginationPageSizes: [10, 25, 50],
                paginationPageSize: 10,
                enablePaginationControls: true,
                columnDefs: [
                            { name: 'Nome', field: 'nomeUsuario' },
                            { name: 'Email', field: 'email' },
                           { name: 'Logo', field: 'imagemUsuario', cellTemplate: "<img style='width: 10%;' data-ng-src='data:image/jpeg;base64,{{row.entity.imagemUsuario}}' alt='' />" },
                             { name: 'Açoes', cellTemplate: ' <button type="button" class="btn btn-default" ng-click="grid.appScope.btnRemove(row)">  <span class="glyphicon glyphicon-remove-circle"></span> </button>  <button type="button" class="btn btn-default" ng-click="grid.appScope.btnUpdate(row)"> <span class="glyphicon glyphicon-pencil"></span></button>' }],
                get: Usuario.query,
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



