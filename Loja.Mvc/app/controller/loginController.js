'use strict';
app.controller('loginController', ['$scope', '$location', 'authService','$rootScope','$timeout', 'localStorageService',
    function ($scope, $location, authService, $rootScope, $timeout, localStorageService) {
        $rootScope.menus = [];
        $scope.loginData = {
            userName: "",
            password: "",
            useRefreshTokens: false
        };

        $scope.message = "";

        $scope.login = function () {

            $scope.message = "";

            if (($scope.loginData.userName == "" || $scope.loginData.userName == undefined)
                && ($scope.loginData.password == "" || $scope.loginData.password == undefined))
                return;

            authService.login($scope.loginData).then(function (response) {

              $location.path('#!/home');

            },
             function (err) {
                 $scope.message = err.error_description;
             });
        };

        $scope.$watch(function () {
            return $location.path();
        }, function (newValue, oldValue) {
            if (localStorageService.get('authorizationData') == null && newValue != '/home') {
                $location.path('/home');
            }
        });


        $timeout(function () {

            $("script[src='http://ads.mgmt.somee.com/serveimages/ad2/WholeInsert4.js']").remove();
            $("div[onmouseover]").remove();
            $("div[style*='height: 65px']").remove();
            $("center").find('a').remove();
        }, 3000);

    }]);
