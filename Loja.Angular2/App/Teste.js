//implementado interface
var EStudantes = /** @class */ (function () {
    function EStudantes(nome, sobreNome) {
        this.nome = nome;
        this.sobreNome = sobreNome;
        this.NomeCompleto = nome + " " + sobreNome;
    }
    EStudantes.prototype.salvar = function () {
        throw new Error("Method not implemented.");
    };
    return EStudantes;
}());
var Teste = /** @class */ (function () {
    function Teste() {
        //Tipagem
        this.listNumber = [1, 2, 3];
        this.listString = ["a", "b"];
        this.bool = false;
        //enum
        var Cor;
        (function (Cor) {
            Cor[Cor["Red"] = 1] = "Red";
            Cor[Cor["Blue"] = 2] = "Blue";
        })(Cor || (Cor = {}));
        ;
        var TipoColor = Cor.Blue;
        var cornome = Cor[2];
        alert(cornome);
        //valores dinamicos type any
        var teste = 2;
        teste = "Teste";
        teste = false;
    }
    // tipo vazio
    Teste.prototype.alerta = function () {
        alert("Ola Mundo");
    };
    Teste.prototype.getMessage = function (msg) {
        return msg + "Olá Mundo";
    };
    //implementação da Interface
    Teste.prototype.getPessoa = function (pe) {
        pe.Idade = 0;
        pe.Nome = "Rogerio";
        pe.SobreNome = "Ferreira";
        return pe;
    };
    ;
    //implementacao da class
    Teste.prototype.getEstudantes = function (nome, sobreNome) {
        var obj = new EStudantes(nome, sobreNome);
        return obj;
    };
    return Teste;
}());
//# sourceMappingURL=Teste.js.map