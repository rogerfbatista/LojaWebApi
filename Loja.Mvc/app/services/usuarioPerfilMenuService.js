'use strict';
app.factory('usuarioPerfilMenuService', ['$http','$q', 'ngAuthSettings', 'localStorageService',
    function ($http,$q, ngAuthSettings, localStorageService) {

        var serviceBase = ngAuthSettings.apiServiceBaseUri;

        var usuarioPerfilMenuServiceFactory = {};

      
      

            var getMenus = function () {

                var token = localStorageService.get("authorizationData");
              

                if (token != null) {
                    var idRole = parseInt(token.IdRole);
                    var empresaId = parseInt(token.empresaId);
                    var chave = token.token;

                    
                    return $http.get(serviceBase + 'api/UsuarioPerfilMenu/Menu/' + idRole + '/' + empresaId + '/' + chave.toString().substring(0, 5), {
                        headers: {
                            'Authorization': 'Bearer ' + token,
                            'Content-Type': 'application/json'
                        }
                    }).then(function (results) {

                        return results.data;
                    });
                }

            };

            usuarioPerfilMenuServiceFactory.getMenus = getMenus;
            return usuarioPerfilMenuServiceFactory;
        
    }]);