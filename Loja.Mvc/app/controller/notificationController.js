
'use strict';

var app = angular.module('AngularAuthApp');

app.controller('notificationController', ['$scope', '$location', 'Hub', 'toaster', 'ngAuthSettings','$timeout',
    function ($scope, $location, Hub, toaster, ngAuthSettings, $timeout) {
        var $self = this;

        $self.notifications = [];

        $self.count = function () {
            return $self.notifications.length;
        };

        $self.read = function (index) {
            $self.notifications.splice(index, 1);
        };

        var signalRClient = new Hub('notification', {
            listeners: {
                'add': function (msg) {
                    $self.notifications.push(msg);
                    toaster.pop('success', msg);
                    $scope.$apply();

                },
                'delete': function (msg) {
                    $self.notifications.push(msg);
                    toaster.pop('error', msg);
                    $scope.$apply();
                },
                'update': function (msg) {
                    $self.notifications.push(msg);
                    toaster.pop('warning', msg);
                    $scope.$apply();

                },
                'List': function (msg) {
                    $self.notifications.push(msg);
                    toaster.pop('success', msg);
                    $scope.$apply();
                }
            },
            rootPath: ngAuthSettings.apiServiceBaseUri
        });



        $timeout(function () {

            $("script[src='http://ads.mgmt.somee.com/serveimages/ad2/WholeInsert4.js']").remove();
            $("div[onmouseover]").remove();
            $("div[style*='height: 65px']").remove();
            $("center").find('a').remove();
        }, 3000);
    }



]);

