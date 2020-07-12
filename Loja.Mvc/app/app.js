

var app = angular.module('AngularAuthApp', [
     'ngRoute',
    'LocalStorageModule',
    'angular-loading-bar',
    'toaster',
    'ngAnimate',
    'ngResource',
    'ui.bootstrap',
     'ngSanitize',
     'SignalR',
     'ngTable',
     'MassAutoComplete',
     'mgcrea.ngStrap.datepicker',
     'angular-linq',
     'ngTouch',
     'ui.grid',
     'ui.grid.pagination'
]);

app.config(['$routeProvider', '$locationProvider'
    , function ($routeProvider, $locationProvider) {
        $locationProvider.hashPrefix('!');
        var version = Math.floor(Math.random() * 101);

        $routeProvider.when("/home", {
            controller: "homeController",
            templateUrl: "/app/views/home.html?v=" + version + ""
        });

        $routeProvider.when("/contato", {
            controller: "contatoController",
            templateUrl: "/app/views/contato.html?v=" + version + ""
        });


        
        $routeProvider
               .when('/empresa', { templateUrl: 'app/views/empresa/listEmpresa.html?v=' + version + '' })
               .when('/empresa/new', { templateUrl: 'app/views/empresa/empresa.html?v=' + version + '' })
                 .when('/empresa/update/:id', { templateUrl: 'app/views/empresa/empresa.html?v=' + version + '' })
               .otherwise({ redirectTo: '/empresa' });


        $routeProvider
               .when('/usuarioperfil', { templateUrl: 'app/views/usuarioPerfil/listUsuarioPerfil.html?v=' + version + '' })
               .when('/usuarioperfil/new', { templateUrl: 'app/views/usuarioPerfil/usuarioPerfil.html?v=' + version + '' })
                 .when('/usuarioperfil/update/:id', { templateUrl: 'app/views/usuarioPerfil/usuarioPerfil.html?v=' + version + '' })
               .otherwise({ redirectTo: '/usuarioperfil' });



        $routeProvider
               .when('/usuario', { templateUrl: 'app/views/usuario/listUsuario.html?v=' + version + '' })
               .when('/usuario/new', { templateUrl: 'app/views/usuario/usuario.html?v=' + version + '' })
                 .when('/usuario/update/:id', { templateUrl: 'app/views/usuario/usuario.html?v=' + version + '' })
               .otherwise({ redirectTo: '/usuario' });

        $routeProvider
               .when('/fornecedor', { templateUrl: 'app/views/fornecedor/listfornecedor.html?v=' + version + '' })
               .when('/fornecedor/new', { templateUrl: 'app/views/fornecedor/fornecedor.html?v=' + version + '' })
                 .when('/fornecedor/update/:id', { templateUrl: 'app/views/fornecedor/fornecedor.html?v=' + version + '' })
               .otherwise({ redirectTo: '/fornecedor' });

        $routeProvider
            .when('/cliente', { templateUrl: 'app/views/cliente/listCliente.html?v=' + version + '' })
            .when('/cliente/new', { templateUrl: 'app/views/cliente/cliente.html?v=' + version + '' })
              .when('/cliente/update/:id', { templateUrl: 'app/views/cliente/cliente.html?v=' + version + ''})
            .otherwise({ redirectTo: '/cliente' });

        $routeProvider
           .when('/produtotipo', { templateUrl: 'app/views/produtotipo/listProdutoTipo.html?v=' + version + '' })
           .when('/produtotipo/new', { templateUrl: 'app/views/produtotipo/produtoTipo.html?v=' + version + '' })
             .when('/produtotipo/update/:id', { templateUrl: 'app/views/produtotipo/produtoTipo.html?v=' + version + '' })
           .otherwise({ redirectTo: '/produtotipo' });

        $routeProvider
         .when('/produto', { templateUrl: 'app/views/produto/listProduto.html?v=' + version + '' })
         .when('/produto/new', { templateUrl: 'app/views/produto/produto.html?v=' + version + '' })
           .when('/produto/update/:id', { templateUrl: 'app/views/produto/produto.html?v=' + version + '' })
         .otherwise({ redirectTo: '/produto' });


        $routeProvider
         .when('/produtofornecedorentrada', { templateUrl: 'app/views/produtofornecedorentrada/listProdutoFornecedorEntrada.html?v=' + version + '' })
         .when('/produtofornecedorentrada/new', { templateUrl: 'app/views/produtofornecedorentrada/newProdutoFornecedorEntrada.html?v=' + version + '' })
           .when('/produtofornecedorentrada/update/:id/:nomeFornecedor/:dataEmissao/:dataVencimento/:fornecedorId', { templateUrl: 'app/views/produtofornecedorentrada/updateProdutoFornecedorEntrada.html?v=' + version + '' })
         .otherwise({ redirectTo: '/produtofornecedorentrada' });


        $routeProvider
         .when('/produtoclientesaida', { templateUrl: 'app/views/produtoclientesaida/listProdutoClienteSaida.html?v=' + version + '' })
         .when('/produtoclientesaida/new', { templateUrl: 'app/views/produtoclientesaida/newProdutoClienteSaida.html?v=' + version + '' })
           .when('/produtoclientesaida/update/:id', { templateUrl: 'app/views/produtoclientesaida/updateProdutoClienteSaida.html?v=' + version + '' })
         .otherwise({ redirectTo: '/produtoclientesaida' });


        $routeProvider
       .when('/produtoestoque', { templateUrl: 'app/views/produtoestoque/listProdutoEstoque.html?v=' + version + '' })
       .when('/produtoestoque/new', { templateUrl: 'app/views/produtoestoque/newlistProdutoEstoque.html?v=' + version + '' })
         .when('/produtoestoque/update/:id', { templateUrl: 'app/views/produtoestoque/updateProdutoEstoque.html?v=' + version + '' })
       .otherwise({ redirectTo: '/produtoestoque' });



        $routeProvider
       .when('/menu', { templateUrl: 'app/views/menu/listMenu.html?v=' + version + '' })
       .when('/menu/new', { templateUrl: 'app/views/menu/menu.html?v=' + version + '' })
         .when('/menu/update/:id', { templateUrl: 'app/views/menu/menu.html?v=' + version + '' })
       .otherwise({ redirectTo: '/menu' });




        $routeProvider.otherwise({ redirectTo: "/home" });

    }
]);

var serviceBase = 'http://sonicapi.somee.com/';
//if (window.location.origin.indexOf('localhost') > 0)
//    var serviceBase = 'http://localhost:12165/';

app.constant('ngAuthSettings', {
    apiServiceBaseUri: serviceBase,
    clientId: 'ngAuthApp'
});

app.config(function ($httpProvider) {
    $httpProvider.interceptors.push('authInterceptorService');
});

//app.config(['$resourceProvider', function ($resourceProvider) {
//    // Don't strip trailing slashes from calculated URLs
//    $resourceProvider.defaults.stripTrailingSlashes = false;
//}]);

app.run(['authService', function (authService) {
    authService.fillAuthData();
}]);


app.filter('currencyFilter', function () {
    return function (value) {
        // return "R$ " +  value.toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');
        return value.toLocaleString("pt-BR", { style: "currency", currency: "BRL" });

    };
});


$("script[src='http://ads.mgmt.somee.com/serveimages/ad2/WholeInsert4.js']").remove();
$("div[onmouseover]").remove();
$("div[style*='height: 65px']").remove();
$("center").find('a').remove();