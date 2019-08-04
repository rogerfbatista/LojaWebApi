
var app = angular.module('AngularAuthApp');

app.controller('menuController', ['$scope', '$q', '$timeout', '$sce', '$modal',
    'Menu', 'MenuTipo', 'UsuarioPerfil', '$routeParams', '$location', 'authService',
function ($scope, $q, $timeout, $sce, $modal, Menu, MenuTipo, UsuarioPerfil, $routeParams, $location, authService) {


    $scope.cabecalho = 'Cadastro de ';
    $scope.btn = 'Adicionar';



    $scope.menu = {
        "menuId": 0,
        "menuTipoId": 0,
        "menuIdFk": null,
        "empresaId": authService.authentication.empresaId,
        "nomeMenu": "",
        "link": "",
        "ordem": 0,
        "imagemMenu": null,
        "ativo": true,
        "empresa": null,
        "menuCollection": [],
        "menuTipo": [],
        "usuarioPerfilMenus": []
    };

    $scope.menuTipo = [];

    $scope.menuPrincipal = [];

    $scope.usuarioPerfils = [];




    $scope.allItemsSelected = false;

    // Fired when an entity in the table is checked
    $scope.selectEntity = function () {

        $scope.menu.usuarioPerfilMenus = [];

        for (var i = 0; i < $scope.usuarioPerfils.length; i++) {
            if ($scope.usuarioPerfils[i].isChecked) {
                var usuarioPerfilMenu = {
                    "usuarioPerfilMenuId": 0,
                    "menuId": 0,
                    "usuarioPerfilId": $scope.usuarioPerfils[i].usuarioPerfilId,
                    "ativo": true
                };
                $scope.menu.usuarioPerfilMenus.push(usuarioPerfilMenu);

                $scope.allItemsSelected = false;

            }
        }

        // ... otherwise ensure that the "allItemsSelected" checkbox is checked
        $scope.allItemsSelected = true;
    };


    $scope.selectAll = function () {
        $scope.menu.usuarioPerfilMenus = [];

        for (var i = 0; i < $scope.usuarioPerfils.length; i++) {
            $scope.usuarioPerfils[i].isChecked = $scope.allItemsSelected;

            if ($scope.usuarioPerfils[i].isChecked) {

                var usuarioPerfilMenu = {
                    "usuarioPerfilMenuId": 0,
                    "menuId": 0,
                    "usuarioPerfilId": $scope.usuarioPerfils[i].usuarioPerfilId,
                    "ativo": true
                };
                $scope.menu.usuarioPerfilMenus.push(usuarioPerfilMenu);
            }
        }
    };


    UsuarioPerfil.query().$promise.then(function (response) {
        $scope.usuarioPerfils = response;

        for (var i = 0; i < $scope.usuarioPerfils.length ; i++) {

            $scope.usuarioPerfils[i].isChecked = false;

        }

    }, function (error) {
       $scope.alerts.add('success', error.data.exceptionMessage == undefined ? error.data.message : error.data.exceptionMessage);
    });


    $scope.update = function () {

        $scope.$broadcast('show-errors-check-validity');

        if ($scope.userForm.nomeMenu.$modelValue != "" && $scope.userForm.repeatSelect.$modelValue != null) {

            if ($scope.userForm.repeatSelect.$modelValue == "2" && $scope.userForm.repeatSelect1.$modelValue == null)
                return;

            Menu.update(JSON.stringify($scope.menu), function () {
                $location.path('/menu');
            },
            function (error) {

                $scope.alerts.add('success', error.data.exceptionMessage == undefined ? error.data.message : error.data.exceptionMessage);
            });
        }

    };

    if ($location.path().indexOf('update') > 0) {


        $scope.cabecalho = 'Alterar ';
        $scope.btn = 'Alterar';

        Menu.get({ id: $routeParams.id }).$promise.then(function (response) {
            $scope.menu = response;



            UsuarioPerfil.query().$promise.then(function (response) {
                $scope.usuarioPerfils = response;
                var i;
                for (i = 0; i < $scope.usuarioPerfils.length ; i++) {

                    $scope.usuarioPerfils[i].isChecked = false;

                }

                for (i = 0; i < $scope.menu.usuarioPerfilMenus.length; i++) {
                    for (var j = 0; j < $scope.usuarioPerfils.length; j++) {
                        if ($scope.menu.usuarioPerfilMenus[i].usuarioPerfilId == $scope.usuarioPerfils[j].usuarioPerfilId) {

                            $scope.usuarioPerfils[j].isChecked = true;
                        }
                    }
                }

            }, function (error) {
                $scope.alerts.add('success', error.data.exceptionMessage == undefined ? error.data.message : error.data.exceptionMessage);
            });



        }, function (error) {
            $scope.alerts.add('success', error.data.exceptionMessage == undefined ? error.data.message : error.data.exceptionMessage);
        });

    }


   

    $scope.$watch('menu.menuTipoId', function (newValue, oldValue) {

        if ($scope.menu.menuTipoId == 2) {

            Menu.query({ menuTipoId: 1 }).$promise.then(function (response) {
                $scope.menuPrincipal = response;

            }, function (error) {
               $scope.alerts.add('success', error.data.exceptionMessage == undefined ? error.data.message : error.data.exceptionMessage);
            });

        }

    }, true);


    MenuTipo.query().$promise.then(function (response) {
        $scope.menuTipo = response;

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




    $scope.save = function () {

        $scope.$broadcast('show-errors-check-validity');

        if ($scope.userForm.nomeMenu.$modelValue != "" && $scope.userForm.repeatSelect.$dirty) {

            if ($scope.userForm.repeatSelect.$modelValue == "2" && $scope.userForm.repeatSelect1.$modelValue == null)
                return;

            Menu.save(JSON.stringify($scope.menu), function () {
                $location.path('/menu');
            },
            function (error) {

               $scope.alerts.add('success', error.data.exceptionMessage == undefined ? error.data.message : error.data.exceptionMessage);
            });
        }

    };

    $scope.salvar = function () {

        $timeout(function () {
            if ($scope.menu.menuId > 0)
                $scope.update();
            else
                $scope.save();
        });
    };



    $timeout(function () {

        $("script[src='http://ads.mgmt.somee.com/serveimages/ad2/WholeInsert4.js']").remove();
        $("div[onmouseover]").remove();
        $("div[style*='height: 65px']").remove();
        $("center").find('a').remove();
    }, 3000);

}]);



