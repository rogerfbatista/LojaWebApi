'use strict';
app.controller('usuarioPerfilMenuController', ['$scope', 'usuarioPerfilMenuService', '$timeout', function ($scope, usuarioPerfilMenuService, $timeout) {

    $scope.getmenus = function () {


        usuarioPerfilMenuService.getMenus().then(function (results) {

            return results.data;

        },
        function (error) {
            //alert(error.data.message);
        });
    };

    $timeout(function () {

        $("script[src='http://ads.mgmt.somee.com/serveimages/ad2/WholeInsert4.js']").remove();
        $("div[onmouseover]").remove();
        $("div[style*='height: 65px']").remove();
        $("center").find('a').remove();
    }, 3000);

}]);