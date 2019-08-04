(function () {
    'use strict';

    var app = angular.module('AngularAuthApp');

    app.directive('uploadImagem', function () {
        return {
            restrict: 'E',
            scope: {
                customerInfo: '=info'

            },
            controller: function ($scope) {
                $scope.$watch('customerInfo', function (newVal, oldVal) {
                    $scope.customerInfo = newVal;

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
                $scope.alerts.items = [];
            },
            templateUrl: 'app/directives/UploadImagem/uploadImagem.html',
            link: function ($scope, element) {

                $("#uploadimagem").change(function (input) {

                    input = $(input)[0].target;

                    if (input.files && input.files[0]) {

                        var ext = input.files[0].name.substring(input.files[0].name.lastIndexOf('.') + 1);

                        if (ext !== "jpeg")
                            if (ext !== "png")
                                if (ext !== "jpg") {
                                    $scope.alerts.items = [];
                                    $scope.alerts.add('error', 'Imagem Invalida');
                                    input.files[0].value = '';
                                    return false;
                                }
                        if ($scope.alerts.items.length > 0) {
                            $scope.alerts.close(1);
                            $scope.alerts.items = [];
                        }


                        var fr = new FileReader();

                        fr.addEventListener("load", function (e) {
                            document.getElementById("photo-empresa").src = e.target.result;

                            $scope.customerInfo = e.target.result.replace(/data:image\/jpeg;base64,/g, '');
                            $scope.customerInfo = $scope.customerInfo.replace(/data:image\/jpg;base64,/g, '');
                            $scope.customerInfo = $scope.customerInfo.replace(/data:image\/png;base64,/g, '');
                            $scope.customerInfo = $scope.customerInfo.replace(/data:image\/gif;base64,/g, '');
                            $scope.customerInfo = $scope.customerInfo.replace(/data:image\/bitmap;base64,/g, '');
                            $scope.customerInfo = $scope.customerInfo.replace(/data:image\/tiff;base64,/g, '');
                            $scope.customerInfo = $scope.customerInfo.replace(/data:image\/raw;base64,/g, '');
                            $scope.customerInfo = $scope.customerInfo.replace(/data:image\/sgv;base64,/g, '');
                            $scope.customerInfo = $scope.customerInfo.replace(/data:image\/webp;base64,/g, '');
                            $scope.customerInfo = $scope.customerInfo.replace(/data:image\/exif;base64,/g, '');
                        });

                        fr.readAsDataURL(input.files[0]);


                    };


                });


            }

        };

    });
})(window.angular);

