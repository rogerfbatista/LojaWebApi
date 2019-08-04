'use strict';

app.factory('authService', ['$http', '$q', 'localStorageService', 'ngAuthSettings',
    function ($http, $q, localStorageService, ngAuthSettings) {

        var serviceBase = ngAuthSettings.apiServiceBaseUri;
        var authServiceFactory = {};

        var authentication = {};
       
        var login = function (loginData) {

            var data = "grant_type=password&username=" + loginData.userName + "&password=" + loginData.password;


            var deferred = $q.defer();

            $http.post(serviceBase + 'api/token', data,
            {
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }

            }).success(function (response) {



                localStorageService.set('authorizationData',
                    {
                        token: response.access_token,
                        userName: loginData.userName,
                        IdRole: response.IdRole,
                        imagemUsuario: response.ImagemUsuario,
                        empresaId: response.empresaId,
                        empresaImagem: response.EmpresaImagem,
                        nomeEmpresa: response.NomeEmpresa,
                        isAuth: true
                    });

             
                authentication.isAuth = true;
                authentication.userName = loginData.userName;
                authentication.imagemUsuario = response.ImagemUsuario;
                authentication.empresaId = response.empresaId;
                authentication.empresaImagem = response.EmpresaImagem;
                authentication.nomeEmpresa = response.NomeEmpresa;
                deferred.resolve(response);

            }).error(function (err, status) {
                logOut();
                deferred.reject(err);
            });

            return deferred.promise;

        };

        var logOut = function () {

            localStorageService.remove('authorizationData');
            localStorageService.remove('reload');


            authentication.isAuth = false;
            authentication.userName = "";
            authentication.imagemUsuario = "";
            authentication.empresaId = 0;
            authentication.empresaImagem = "";
            authentication.nomeEmpresa = "";
        };

        var fillAuthData = function () {

            var authData = localStorageService.get('authorizationData');
            if (authData) {
                authentication.isAuth = true;
                authentication.userName = authData.userName;
                authentication.imagemUsuario = authData.imagemUsuario;
                authentication.empresaId = authData.empresaId;
                authentication.empresaImagem = authData.empresaImagem;
                authentication.nomeEmpresa = authData.nomeEmpresa;
            }

        };



        authServiceFactory.login = login;
        authServiceFactory.logOut = logOut;
        authServiceFactory.fillAuthData = fillAuthData;
        authServiceFactory.authentication = authentication;
      
        return authServiceFactory;
    }]);