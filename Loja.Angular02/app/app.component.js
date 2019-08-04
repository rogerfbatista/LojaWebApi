System.register(['angular2/core', './app.service'], function(exports_1) {
    var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
        var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
        if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
        else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
        return c > 3 && r && Object.defineProperty(target, key, r), r;
    };
    var __metadata = (this && this.__metadata) || function (k, v) {
        if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
    };
    var core_1, app_service_1;
    var AppComponent;
    return {
        setters:[
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (app_service_1_1) {
                app_service_1 = app_service_1_1;
            }],
        execute: function() {
            AppComponent = (function () {
                function AppComponent(_appService) {
                    this._appService = _appService;
                    this.titulo = 'Angular 2';
                    this.mensagem = '';
                    this.nome = '';
                    this.getNomeInicial();
                }
                AppComponent.prototype.getNomeInicial = function () {
                    this.nome = this._appService.getNome();
                };
                AppComponent.prototype.onClickMe = function () {
                    this.mensagem = "Macoratti .net - quase tudo para .NET";
                };
                AppComponent = __decorate([
                    core_1.Component({
                        selector: 'meu-app',
                       template: '{{titulo }}<p> Nome : <input [(ngModel)] = "nome" ><p>{{nome}}<p><button (click)= "onClickMe()">Clique Aqui</button><p>{{ mensagem }}',
                        providers: [app_service_1.AppService]
                    }), 
                    __metadata('design:paramtypes', [app_service_1.AppService])
                ], AppComponent);
                return AppComponent;
            })();
            exports_1("AppComponent", AppComponent);
        }
    }
});
//# sourceMappingURL=app.component.js.map