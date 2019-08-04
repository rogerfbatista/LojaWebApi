

//implementado interface
class EStudantes implements TesteInterface.IPessoa{

    Nome: string;
    SobreNome: string;
    Idade?: number;
    salvar(): void {
        throw new Error("Method not implemented.");
    }
    NomeCompleto: string;
    constructor(public nome: string, public sobreNome: string) {

        this.NomeCompleto = nome + " " + sobreNome;
    }

}



class Teste {

    //Tipagem
    listNumber: number[] = [1, 2, 3];
    listString: Array<string> = ["a", "b"];
    bool: boolean = false;


    constructor() {


        //enum
        enum Cor { Red = 1, Blue = 2 };
        var TipoColor = Cor.Blue;

        var cornome = Cor[2];
        alert(cornome);

        //valores dinamicos type any
        var teste: any = 2
        teste = "Teste"
        teste = false;


    }
    // tipo vazio
    alerta(): void {
        alert("Ola Mundo");
    }

    getMessage(msg: string): string {

        return msg + "Olá Mundo";
    }
    //implementação da Interface
    getPessoa(pe: TesteInterface.IPessoa): TesteInterface.IPessoa {

        pe.Idade = 0;
        pe.Nome = "Rogerio";
        pe.SobreNome = "Ferreira";

        return pe;
    };

    //implementacao da class
    getEstudantes(nome: string, sobreNome: string): EStudantes {

        var obj = new EStudantes(nome, sobreNome);
        return obj;
    }

}