import { Component } from 'angular2/core';
import { AppService } from './app.service';

@Component({
    selector: 'meu-app',
    //template: '{{titulo }}<p> Nome : <input [(ngModel)] = "nome" ><p>{{nome}}<p><button (click)= "onClickMe()">Clique Aqui</button><p>{{ mensagem }}',
      providers:[AppService]
})
export class AppComponent {
    titulo: string = 'Angular 2';
    mensagem = '';
    nome: string = '';

    constructor(private _appService: AppService) {
        this.getNomeInicial();
    }

    getNomeInicial() {
        this.nome = this._appService.getNome();
    }

    onClickMe() {
        this.mensagem = "Macoratti .net - quase tudo para .NET";
    }

}