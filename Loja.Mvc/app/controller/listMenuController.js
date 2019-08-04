
var app = angular.module('AngularAuthApp');

app.controller('listMenuController', ['$scope', '$modal',
    'Menu', 'NgTableParams', '$filter', '$routeParams', '$location', 'authService', '$timeout',
        function ($scope, $modal, Menu, NgTableParams, $filter, $routeParams, $location, authService, $timeout) {


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


                $scope.moveUpdate = function (menuId) {
                    var location = '/menu/update/' + menuId;

                    $location.path(location);
                };



                $scope.gridDirective = {
                    delete: {
                        method: Menu.delete,
                        mensagemAfterDelete: 'O Menu',
                        id: 'menuId'
                    },
                    update: {
                        method: $scope.moveUpdate,
                        id: 'menuId'
                    },
                    enableSearchText: true,
                    paginationPageSizes: [10, 25, 50],
                    paginationPageSize: 10,
                    enablePaginationControls: true,
                    columnDefs: [
                                { name: 'Nome', field: 'nomeMenu' },
                                { name: 'link', field: 'link' },
                                 { name: 'Logo', field: 'imagemMenu', cellTemplate: "<img style='width: 10%;' data-ng-src='data:image/jpeg;base64,{{row.entity.imagemMenu}}' alt='' />" },
                                 { name: 'Açoes', cellTemplate: ' <button type="button" class="btn btn-default" ng-click="grid.appScope.btnRemove(row)">  <span class="glyphicon glyphicon-remove-circle"></span> </button>  <button type="button" class="btn btn-default" ng-click="grid.appScope.btnUpdate(row)"> <span class="glyphicon glyphicon-pencil"></span></button>' }],
                    get: Menu.query,
                    getId:{empresaId: $scope.authentication.empresaId },
                    onRegisterApi: function (gridApi) {
                        $scope.gridApi = gridApi;
                    }
                };
            

                $timeout(function () {

                    $("script[src='http://ads.mgmt.somee.com/serveimages/ad2/WholeInsert4.js']").remove();
                    $("div[onmouseover]").remove();
                    $("div[style*='height: 65px']").remove();
                    $("center").find('a').remove();
                    $('[data-toggle="tooltip"]').tooltip();

                }, 3000);


            }]);



