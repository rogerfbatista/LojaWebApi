using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace Loja.Mvc.Tests
{
    [TestClass]
    public class A_ProdutoTest : BaseTest
    {
        public A_ProdutoTest():base(false)
        {

        }
        [TestMethod]
        public void A_Cadastro_Produto_Salvar()
        {

            this.Login("visitante", "visitante");

            this.AguardarSegundos(4);

            this.ProcurarElemento(By.LinkText("Produto")).Click();

            this.AguardarSegundos(2);

            this.ProcurarElemento(By.LinkText("Lista de Produtos")).Click();

            this.AguardarSegundos(3);

            this.ProcurarElemento(By.XPath("//a[.='Novo Produto']")).Click();

            this.AguardarSegundos(2);

            this.SelectElemento(By.Id("repeatSelect"));

            this.AguardarSegundos(2);

            this.SelectElementoValor("6");

            this.ProcurarElemento(By.Name("nomeProduto")).SendKeys("Tenis Vans");

            this.ProcurarElemento(By.Name("codigoReferencia")).SendKeys("2513444");

            this.AguardarSegundos(2);

            this.EscolherArquivoImportacao(By.Name("imagem"), @"C:\Users\Bianca\TenisVans.jpg");

            this.AguardarSegundos(2);

            this.ProcurarElemento(By.XPath("//button[.='Adicionar']")).Click();

            this.Fim();
        }


        [TestMethod]
        public void B_Cadastro_Produto_Alterar()
        {

            this.Login("visitante", "visitante");

            this.AguardarSegundos(3);

            this.ProcurarElemento(By.LinkText("Produto")).Click();

            this.AguardarSegundos(2);

            this.ProcurarElemento(By.LinkText("Lista de Produtos")).Click();

            this.AguardarSegundos(3);

            this.ProcurarElemento(By.XPath("//input[@data-ng-model='searchText']")).SendKeys("Tenis");

            this.AguardarSegundos(2);

            this.ProcurarElemento(By.ClassName("glyphicon-pencil")).Click();

            this.AguardarSegundos(2);

            this.ProcurarElemento(By.Name("nomeProduto")).Clear();

            this.AguardarSegundos(2);

            this.ProcurarElemento(By.Name("nomeProduto")).SendKeys("Tenis Vans 38-40");

            this.AguardarSegundos(2);

            this.ProcurarElemento(By.Name("codigoReferencia")).Clear();

            this.AguardarSegundos(2);

            this.ProcurarElemento(By.Name("codigoReferencia")).SendKeys("123456");

            this.AguardarSegundos(1);

            this.ProcurarElemento(By.XPath("//button[.='Alterar']")).Click();

            this.Fim();
        }

        //[TestMethod]
        public void Cadastro_Produto_C_Excluir()
        {

            this.Login("visitante", "visitante");

            this.AguardarSegundos(4);

            this.ProcurarElemento(By.LinkText("Produto")).Click();

            this.AguardarSegundos(2);

            this.ProcurarElemento(By.LinkText("Lista de Produtos")).Click();

            this.AguardarSegundos(3);

            this.ProcurarElemento(By.XPath("//input[@data-ng-model='searchText']")).SendKeys("Tenis");

            this.AguardarSegundos(2);

            this.ProcurarElemento(By.ClassName("glyphicon-remove-circle")).Click();

            this.AguardarSegundos(1);

            this.ProcurarElemento(By.XPath("//button[.='Confirmar']")).Click();

            this.Fim();
        }


    }
}
