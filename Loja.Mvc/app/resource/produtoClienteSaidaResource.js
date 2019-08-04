
var app = angular.module('AngularAuthApp');

app.factory('ProdutoClienteSaidaPagination', ['$resource', 'ngAuthSettings', 'localStorageService',
        function ($resource, ngAuthSettings, localStorageService) {

            var token = localStorageService.get("authorizationData");

            if (token != null)
                token = token.token;


            return $resource(ngAuthSettings.apiServiceBaseUri + 'api/ProdutoClienteSaida/:pageNumber/:pageSize/:empresaId',
                { pageNumber: "@pageNumber",pageSize:"@pageSize" },
              {
                  'query': {
                      method: 'GET',
                      headers: {
                          'Authorization': 'Bearer ' + token
                      },
                      isArray: true
                  }
              });
        }]);




app.factory('ProdutoClienteSaidaAll', ['$resource', 'ngAuthSettings', 'localStorageService',
        function ($resource, ngAuthSettings, localStorageService) {

            var token = localStorageService.get("authorizationData");

            if (token != null)
                token = token.token;


            return $resource(ngAuthSettings.apiServiceBaseUri + 'api/ProdutoClienteSaida/ProdutoClienteSaidaAll/:guid',
                { guid: '@empresaId' },
                {
                    headers: {
                        'Authorization': 'Bearer ' + token,
                        'Content-Type': 'application/json'
                    }
                }
            );
        }]);


app.factory('ProdutoClienteSaida', ['$resource', 'ngAuthSettings', 'localStorageService',
        function ($resource, ngAuthSettings, localStorageService) {

            var token = localStorageService.get("authorizationData");

            if (token != null)
                token = token.token;


            return $resource(ngAuthSettings.apiServiceBaseUri + 'api/ProdutoClienteSaida/:guid',
                { guid: '@id' },
                {},
                {
                    headers: {
                        'Authorization': 'Bearer ' + token,
                        'Content-Type': 'application/json'
                    }
                }
            );
        }]);










