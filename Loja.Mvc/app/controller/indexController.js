'use strict';

app.controller('indexController', ['$scope', '$location', 'authService', 'usuarioPerfilMenuService',
    'localStorageService', '$rootScope','$timeout',
function ($scope, $location, authService, usuarioPerfilMenuService,
    localStorageService, $rootScope, $timeout) {
    var fnMenu = [];
    $rootScope.menus = [];
    $scope.logOut = function () {
        authService.logOut();
        $location.path('/home');
    };

    $scope.year = function () {
        return new Date().getFullYear();
    };


    $scope.authentication = authService.authentication;

   

    $scope.$watch('authentication.isAuth', function (newValue, oldValue) {
        
        if ($scope.authentication.isAuth == true) {
             $scope.getMenus();

        }

    },true);
    

    $scope.getMenus = function () {
        fnMenu = usuarioPerfilMenuService.getMenus();

        return fnMenu.then(function (result) {
            $rootScope.menus  = result;
             
        });
    };


    $timeout(function () {

        $("script[src='http://ads.mgmt.somee.com/serveimages/ad2/WholeInsert4.js']").remove();
        $("div[onmouseover]").remove();
        $("div[style*='height: 65px']").remove();
        $("center").find('a').remove();
    }, 3000);



}]);