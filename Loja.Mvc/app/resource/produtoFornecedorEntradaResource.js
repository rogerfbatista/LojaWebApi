
angular.module('AngularAuthApp').factory('ProdutoFornecedorEntrada', ['$resource', 'ngAuthSettings', 'localStorageService',
        function ($resource, ngAuthSettings, localStorageService) {

            var token = localStorageService.get("authorizationData");

            if (token != null)
                token = token.token;


            return $resource(ngAuthSettings.apiServiceBaseUri + 'api/ProdutoFornecedorEntrada/:guid',
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

angular.module('AngularAuthApp').factory('ProdutoFornecedorEntradaAll', ['$resource', 'ngAuthSettings', 'localStorageService',
        function ($resource, ngAuthSettings, localStorageService) {

            var token = localStorageService.get("authorizationData");

            if (token != null)
                token = token.token;


            return $resource(ngAuthSettings.apiServiceBaseUri + 'api/ProdutoFornecedorEntrada/ProdutoFornecedorEntradaAll/:guid',
                { guid: '@empresaId' },
                {
                    headers: {
                        'Authorization': 'Bearer ' + token,
                        'Content-Type': 'application/json'
                    }
                }
            );
        }]);









