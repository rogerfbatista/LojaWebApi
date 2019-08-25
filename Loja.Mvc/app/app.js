

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

        $routeProvider.when("/home", {
            controller: "homeController",
            templateUrl: "/app/views/home.html?v=6"
        });

        $routeProvider.when("/contato", {
            controller: "contatoController",
            templateUrl: "/app/views/contato.html?v=6"
        });



        $routeProvider
               .when('/empresa', { templateUrl: 'app/views/empresa/listEmpresa.html?v=6' })
               .when('/empresa/new', { templateUrl: 'app/views/empresa/empresa.html?v=6' })
                 .when('/empresa/update/:id', { templateUrl: 'app/views/empresa/empresa.html?v=6' })
               .otherwise({ redirectTo: '/empresa' });


        $routeProvider
               .when('/usuarioperfil', { templateUrl: 'app/views/usuarioPerfil/listUsuarioPerfil.html?v=6' })
               .when('/usuarioperfil/new', { templateUrl: 'app/views/usuarioPerfil/usuarioPerfil.html?v=6' })
                 .when('/usuarioperfil/update/:id', { templateUrl: 'app/views/usuarioPerfil/usuarioPerfil.html?v=6' })
               .otherwise({ redirectTo: '/usuarioperfil' });



        $routeProvider
               .when('/usuario', { templateUrl: 'app/views/usuario/listUsuario.html?v=6' })
               .when('/usuario/new', { templateUrl: 'app/views/usuario/usuario.html?v=6' })
                 .when('/usuario/update/:id', { templateUrl: 'app/views/usuario/usuario.html?v=6' })
               .otherwise({ redirectTo: '/usuario' });

        $routeProvider
               .when('/fornecedor', { templateUrl: 'app/views/fornecedor/listfornecedor.html?v=6' })
               .when('/fornecedor/new', { templateUrl: 'app/views/fornecedor/fornecedor.html?v=6' })
                 .when('/fornecedor/update/:id', { templateUrl: 'app/views/fornecedor/fornecedor.html?v=6' })
               .otherwise({ redirectTo: '/fornecedor' });

        $routeProvider
            .when('/cliente', { templateUrl: 'app/views/cliente/listCliente.html?v=6' })
            .when('/cliente/new', { templateUrl: 'app/views/cliente/cliente.html?v=6' })
              .when('/cliente/update/:id', { templateUrl: 'app/views/cliente/cliente.html?v=6' })
            .otherwise({ redirectTo: '/cliente' });

        $routeProvider
           .when('/produtotipo', { templateUrl: 'app/views/produtotipo/listProdutoTipo.html?v=6' })
           .when('/produtotipo/new', { templateUrl: 'app/views/produtotipo/produtoTipo.html?v=6' })
             .when('/produtotipo/update/:id', { templateUrl: 'app/views/produtotipo/produtoTipo.html?v=6' })
           .otherwise({ redirectTo: '/produtotipo' });

        $routeProvider
         .when('/produto', { templateUrl: 'app/views/produto/listProduto.html?v=6' })
         .when('/produto/new', { templateUrl: 'app/views/produto/produto.html?v=6' })
           .when('/produto/update/:id', { templateUrl: 'app/views/produto/produto.html?v=6' })
         .otherwise({ redirectTo: '/produto' });


        $routeProvider
         .when('/produtofornecedorentrada', { templateUrl: 'app/views/produtofornecedorentrada/listProdutoFornecedorEntrada.html?v=6' })
         .when('/produtofornecedorentrada/new', { templateUrl: 'app/views/produtofornecedorentrada/newProdutoFornecedorEntrada.html?v=6' })
           .when('/produtofornecedorentrada/update/:id/:nomeFornecedor/:dataEmissao/:dataVencimento/:fornecedorId', { templateUrl: 'app/views/produtofornecedorentrada/updateProdutoFornecedorEntrada.html?v=6' })
         .otherwise({ redirectTo: '/produtofornecedorentrada' });


        $routeProvider
         .when('/produtoclientesaida', { templateUrl: 'app/views/produtoclientesaida/listProdutoClienteSaida.html?v=6' })
         .when('/produtoclientesaida/new', { templateUrl: 'app/views/produtoclientesaida/newProdutoClienteSaida.html?v=6' })
           .when('/produtoclientesaida/update/:id', { templateUrl: 'app/views/produtoclientesaida/updateProdutoClienteSaida.html?v=6' })
         .otherwise({ redirectTo: '/produtoclientesaida' });


        $routeProvider
       .when('/produtoestoque', { templateUrl: 'app/views/produtoestoque/listProdutoEstoque.html?v=6' })
       .when('/produtoestoque/new', { templateUrl: 'app/views/produtoestoque/newlistProdutoEstoque.html?v=6' })
         .when('/produtoestoque/update/:id', { templateUrl: 'app/views/produtoestoque/updateProdutoEstoque.html?v=6' })
       .otherwise({ redirectTo: '/produtoestoque' });



        $routeProvider
       .when('/menu', { templateUrl: 'app/views/menu/listMenu.html' })
       .when('/menu/new', { templateUrl: 'app/views/menu/menu.html' })
         .when('/menu/update/:id', { templateUrl: 'app/views/menu/menu.html' })
       .otherwise({ redirectTo: '/menu' });




        $routeProvider.otherwise({ redirectTo: "/home" });

    }
]);

var serviceBase = 'http://localhost:12165/';
//var serviceBase = 'http://www.sonicapi11.somee.com/';
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