'use strict';
app.controller('homeController', ['$scope', '$modal', '$timeout', function ($scope, $modal, $timeout) {


    $scope.openModal = function (item, index) {
        var modalInstance = $modal.open({
            templateUrl: 'app/views/modal.html',
            controller: 'modalController',
            resolve: {
                items: function () {
                    return { obj: item, index: index };
                }
            }
        });



    };

    $timeout(function () {

        $("script[src='http://ads.mgmt.somee.com/serveimages/ad2/WholeInsert4.js']").remove();
        $("div[onmouseover]").remove();
        $("div[style*='height: 65px']").remove();
        $("center").find('a').remove();
    }, 3000);

}]);