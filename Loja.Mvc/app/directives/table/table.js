(function () {
    'use strict';

    var app = angular.module('AngularAuthApp');

    app.directive('tableDirective', function ($modal, $filter) {
        return {
            restrict: 'E',
            scope: {
                gridDirective: '=grid'

            },
            link: function ($scope) {

                var data = [];

                $scope.filterOptions = {
                    filterText: ''
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



                var empresaId = $scope.gridDirective.empresaId == undefined ?
                    0 : $scope.gridDirective.empresaId;

                var paginationOptions = {
                    empresaId: empresaId,
                    pageNumber: 1,
                    pageSize: 10,
                    sort: null
                };


                var paginationPageSizes = $scope.gridDirective.paginationPageSizes == undefined ?
                [25, 50, 75] : $scope.gridDirective.paginationPageSizes;

                var paginationPageSize = $scope.gridDirective.paginationPageSize == undefined ?
                    25 : $scope.gridDirective.paginationPageSize;


                var columnDefs = $scope.gridDirective.columnDefs == undefined ?
                [] : $scope.gridDirective.columnDefs;


                var enablePaginationControls = $scope.gridDirective.enablePaginationControls == undefined ?
              [] : $scope.gridDirective.enablePaginationControls;



                $scope.enableSearchText = $scope.gridDirective.enableSearchText == undefined ?
               false : $scope.gridDirective.enableSearchText;



                var useExternalPagination = $scope.gridDirective.useExternalPagination == undefined ?
                  false : $scope.gridDirective.useExternalPagination;

                var useExternalSorting = $scope.gridDirective.useExternalSorting == undefined ?
           false : $scope.gridDirective.useExternalSorting;

                var onRegisterApi = $scope.gridDirective.onRegisterApi == undefined ?
             function () { } : $scope.gridDirective.onRegisterApi;


                $scope.getPage = function () {

                    $scope.gridDirective.get({ pageNumber: paginationOptions.pageNumber, pageSize: paginationOptions.pageSize, empresaId: paginationOptions.empresaId }).$promise.then(function (response) {
                        debugger;
                        $scope.gridOptions.totalItems = response[0].recordsTotal;
                        var firstRow = (paginationOptions.pageNumber - 1) * paginationOptions.pageSize;
                        $scope.gridOptions.data = response[0].list;

                    }, function (error) {
                        $scope.alerts.add('error', error.data.exceptionMessage == undefined ? error.data.message : error.data.exceptionMessage);
                    });

                    
                };

                    if (useExternalPagination) {

                        $scope.gridDirective.getSerachText({ empresaId: paginationOptions.empresaId}).$promise.then(function (response) {
                            debugger;
                            data = response;

                        }, function (error) {
                            $scope.alerts.add('error', error.data.exceptionMessage == undefined ? error.data.message : error.data.exceptionMessage);
                        });
                    }

                var getId = $scope.gridDirective.getId == undefined ?
            null : $scope.gridDirective.getId;


                if (useExternalPagination) {
                    
                    onRegisterApi = function (gridApi) {


                        $scope.gridApi = gridApi;
                        $scope.gridApi.core.on.sortChanged($scope, function (grid, sortColumns) {
                            if (sortColumns.length == 0) {
                                paginationOptions.sort = null;
                            } else {
                                paginationOptions.sort = sortColumns[0].sort.direction;
                            }
                            $scope.getPage();
                        });
                        gridApi.pagination.on.paginationChanged($scope, function (newPage, pageSize) {
                            paginationOptions.pageNumber = newPage;
                            paginationOptions.pageSize = pageSize;
                            $scope.getPage();
                        });
                    };
                    $scope.getPage();
                } else {

                    $scope.gridDirective.get(getId).$promise.then(function (response) {
                        $scope.gridOptions.data = data = response;
                    }, function (error) {
                        $scope.alerts.add('error', error.data.exceptionMessage == undefined ? error.data.message : error.data.exceptionMessage);
                    });
                }

                $scope.gridOptions = {
                    paginationPageSizes: paginationPageSizes,
                    paginationPageSize: paginationPageSize,
                    columnDefs: columnDefs,
                    data: [],
                    onRegisterApi: onRegisterApi,
                    enablePaginationControls: enablePaginationControls,
                    useExternalPagination: useExternalPagination,
                    useExternalSorting: useExternalSorting

                };





                $scope.btnRemove = function (row) {

                    var item = row.entity;
                    var index = parseInt(row.entity.$id);

                    var modalInstance = $modal.open({
                        templateUrl: 'app/views/removeModal.html',
                        controller: 'removeModalController',
                        resolve: {
                            items: function () {
                                return { obj: item, index: index };
                            }
                        }
                    });

                    modalInstance.result.then(function (param) {

                        $scope.gridDirective.delete.method({ id: param.obj[$scope.gridDirective.delete.id] }, function () {
                            $scope.gridOptions.data.splice(index - 1, 1);
                            $scope.alerts.add('success', $scope.gridDirective.delete.mensagemAfterDelete + ' foi excluído com sucesso.');
                        }, function (error) {

                            $scope.alerts.add('success', error.data.exceptionMessage == undefined ? error.data.message : error.data.exceptionMessage);
                        });

                    });
                };

                $scope.refreshData = function () {
                    
                    $scope.gridOptions.data = $filter('filter')(data, $scope.searchText);
                };

                $scope.btnUpdate = function (row) {
                    var id = row.entity[$scope.gridDirective.update.id];
                    if ($scope.gridDirective.update.objeto == undefined)
                        $scope.gridDirective.update.method(id);
                    else {
                        $scope.gridDirective.update.method(row.entity);
                    }
                };

            },
            templateUrl: 'app/directives/table/table.html',



        };

    });
})(window.angular);

