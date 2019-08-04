module TesteInterface {

    //implemntar em outros arquivos export
   export interface IPessoa {
        Nome: string;
        SobreNome: string;
        Idade?: number;
        salvar(): void;
    }
}
