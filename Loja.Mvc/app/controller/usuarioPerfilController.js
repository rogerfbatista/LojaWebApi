
var app = angular.module('AngularAuthApp');

app.controller('usuarioPerfilController', ['$scope', '$modal', 'UsuarioPerfil', 'Servico', 'NgTableParams', '$filter',
                '$routeParams', '$location', '$rootScope', '$timeout',
        function ($scope, $modal, UsuarioPerfil, Servico, NgTableParams, $filter, $routeParams, $location, $rootScope, $timeout) {

            
            $scope.usuarioPerfil = {
                'usuarioPerfilId': 0,
                'nomeUsuarioPerfil': "",
                'imagemUsuarioPerfil': '',
                'ativo': true,
                'usuarios': [],
                'servicoUsuarioPerfil': []
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
                    UsuarioPerfil.save(JSON.stringify($scope.usuarioPerfil), function () {
                        $location.path('/usuarioperfil');
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
                    UsuarioPerfil.update(JSON.stringify($scope.usuarioPerfil), function () {
                        $location.path('/usuarioperfil');

                    },
                    function (error) {

                        $scope.alerts.add('success', error.data.exceptionMessage == undefined ? error.data.message : error.data.exceptionMessage);
                    });
                }
            };

            $scope.salvar = function () {

                $timeout(function(){ 
                if ($scope.usuarioPerfil.usuarioPerfilId > 0)
                    $scope.update();
                else
                    $scope.save();
            });
        };

            $scope.moveUpdate = function (id) {

                var location = '/usuarioperfil/update/' + id;


                $location.path(location);
            };




            $scope.allItemsSelected = false;

            // Fired when an entity in the table is checked
            $scope.selectEntity = function () {

                $scope.usuarioPerfil.servicoUsuarioPerfil = [];

                for (var i = 0; i < $scope.servico.length; i++) {

                    if ($scope.servico[i].isChecked) {

                        var servicoUsuario = {
                            "servicoUsuarioPerfilId": 0,
                            "servicoId": $scope.servico[i].servicoId,
                            "usuarioPerfilId": $scope.usuarioPerfil.usuarioPerfilId,
                            "ativo": true,
                            "usuarioPerfil": []
                        };
                        $scope.usuarioPerfil.servicoUsuarioPerfil.push(servicoUsuario);
                    }

                    $scope.allItemsSelected = false;

                }


                // ... otherwise ensure that the "allItemsSelected" checkbox is checked
                $scope.allItemsSelected = true;
            };


            $scope.selectAll = function () {
                $scope.usuarioPerfil.servicoUsuarioPerfil = [];

                for (var i = 0; i < $scope.servico.length; i++) {
                    $scope.servico[i].isChecked = $scope.allItemsSelected;

                    if ($scope.servico[i].isChecked) {

                        var servicoUsuario = {
                            "servicoUsuarioPerfilId": 0,
                            "servicoId": $scope.servico[i].servicoId,
                            "usuarioPerfilId": $scope.usuarioPerfil.usuarioPerfilId,
                            "ativo": true,
                            "usuarioPerfil": []
                        };
                        $scope.usuarioPerfil.servicoUsuarioPerfil.push(servicoUsuario);
                    }
                }
            };


            if ($location.path().indexOf('new') > 0) {

                $scope.cabecalho = 'Cadastro de ';
                $scope.btn = 'Adicionar';

                Servico.query().$promise.then(function (response) {
                    $scope.servico = response;

                    for (var i = 0; i < $scope.servico.length; i++) {

                        $scope.servico[i].isChecked = false;

                    }

                }, function (error) {
                    $scope.alerts.add('success', error.data.exceptionMessage == undefined ? error.data.message : error.data.exceptionMessage);
                });
            }


            if ($location.path().indexOf('update') > 0) {
            

                $scope.cabecalho = 'Alterar ';  
                $scope.btn = 'Alterar';

                UsuarioPerfil.get({ id: $routeParams.id }).$promise.then(function (response) {
                    $scope.usuarioPerfil = response;

                    Servico.query().$promise.then(function (response) {

                        $scope.servico = response;
                        var i;
                        for (i = 0; i < $scope.servico.length; i++) {

                            $scope.servico[i].isChecked = false;

                        }

                        for (i = 0; i < $scope.usuarioPerfil.servicoUsuarioPerfil.length; i++) {
                            for (var j = 0; j < $scope.servico.length; j++) {
                                if ($scope.usuarioPerfil.servicoUsuarioPerfil[i].servicoId == $scope.servico[j].servicoId) {

                                    $scope.servico[j].isChecked = true;
                                }
                            }
                        }

                    }, function (error) {
                        $scope.alerts.add('success', error.data.exceptionMessage == undefined ? error.data.message : error.data.exceptionMessage);
                    });

                }, function (error) {

                    $scope.alerts.add('success', error.data.exceptionMessage == undefined ? error.data.message : error.data.exceptionMessage);
                });


            };


            if ($location.path() == "/usuarioperfil") {

                $scope.gridDirective = {
                    delete: {
                        method: UsuarioPerfil.delete,
                        mensagemAfterDelete: 'O Perfil Usuario',
                        id: 'usuarioPerfilId'
                    },
                    update: {
                        method: $scope.moveUpdate,
                        id: 'usuarioPerfilId'
                    },
                    enableSearchText: true,
                    paginationPageSizes: [10, 25, 50],
                    paginationPageSize: 10,
                    enablePaginationControls: true,
                    columnDefs: [
                                { name: 'Nome', field: 'nomeUsuarioPerfil' },
                                 { name: 'Logo', field: 'imagemUsuarioPerfil', cellTemplate: "<img style='width: 10%;' data-ng-src='data:image/jpeg;base64,{{row.entity.imagemUsuarioPerfil}}' alt='' />" },
                                 { name: 'Açoes', cellTemplate: ' <button type="button" class="btn btn-default" ng-click="grid.appScope.btnRemove(row)">  <span class="glyphicon glyphicon-remove-circle"></span> </button>  <button type="button" class="btn btn-default" ng-click="grid.appScope.btnUpdate(row)"> <span class="glyphicon glyphicon-pencil"></span></button>' }],
                    get: UsuarioPerfil.query,
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



