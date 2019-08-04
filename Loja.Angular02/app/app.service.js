System.register([], function(exports_1) {
    var AppService;
    return {
        setters:[],
        execute: function() {
            AppService = (function () {
                function AppService() {
                }
                AppService.prototype.getNome = function () {
                    return 'Macoratti .net';
                };
                return AppService;
            })();
            exports_1("AppService", AppService);
        }
    }
});
//# sourceMappingURL=app.service.js.map