﻿


angular.module('AngularAuthApp').factory('Usuario', ['$resource', 'ngAuthSettings', 'localStorageService',
        function ($resource, ngAuthSettings, localStorageService) {

            var token = localStorageService.get("authorizationData");

            if (token != null)
                token = token.token;


            return $resource(ngAuthSettings.apiServiceBaseUri + 'api/Usuario/:guid',
                { guid: '@id' },
                {
                    headers: {
                        'Authorization': 'Bearer ' + token,
                        'Content-Type': 'application/json'
                    }
                },
                {
                    "update": { method: "PUT", isArray: true },
                    "save": { method: "POST", isArray: true },
                    
                }
            );
        }]);


