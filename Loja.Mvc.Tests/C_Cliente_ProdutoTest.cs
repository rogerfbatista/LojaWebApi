using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace Loja.Mvc.Tests
{
    [TestClass]
    public class C_Cliente_ProdutoTest : BaseTest
    {
        public C_Cliente_ProdutoTest()
            : base(false)
        {

        }
        [TestMethod]
        public void D_Cliente_Produto_Salvar()
        {

            this.Login("rogerfbatista@gmail.com", "@bianca");

            this.AguardarSegundos(4);

            this.ProcurarElemento(By.LinkText("Vendas")).Click();

            this.AguardarSegundos(2);

            this.ProcurarElemento(By.LinkText("Cliente x Produto")).Click();

            this.AguardarSegundos(3);

            this.ProcurarElemento(By.Id("txtcliente")).SendKeys("Rogerio");
            this.AguardarSegundos(2);
            this.ProcurarElemento(By.Id("txtcliente")).SendKeys(Keys.Backspace);
            this.AguardarSegundos(2);
            var existe = true;


            while (existe)
            {
                existe = this.ExisteElemento(By.ClassName("Cliente"));
            }
            
            this.ProcurarElemento(By.PartialLinkText("Rogerio Ferreira")).Click();


            this.ProcurarElemento(By.Id("Text1")).SendKeys("Tenis Vans");
            this.AguardarSegundos(2);
            this.ProcurarElemento(By.Id("Text1")).SendKeys(Keys.Backspace);
            this.AguardarSegundos(2);
            existe = true;
            while (existe)
            {
                existe = this.ExisteElemento(By.ClassName("Produto"));
            }

            this.ProcurarElemento(By.PartialLinkText("Tenis Vans 38-40")).Click();

            this.ProcurarElemento(By.Name("quantidadeSaida")).SendKeys("1");

            this.AguardarSegundos(1);

            this.ProcurarElemento(By.XPath("//button[.='Adicionar']")).Click();

            this.ProcurarElemento(By.Id("Text1")).SendKeys("Camisa Polo GG");
            this.AguardarSegundos(2);
            this.ProcurarElemento(By.Id("Text1")).SendKeys(Keys.Backspace);
            this.AguardarSegundos(2);
            existe = true;
            while (existe)
            {
                existe = this.ExisteElemento(By.ClassName("Produto"));
            }

            this.ProcurarElemento(By.PartialLinkText("Camisa Polo GG")).Click();

            this.ProcurarElemento(By.Name("quantidadeSaida")).SendKeys("2");

            this.AguardarSegundos(1);

            this.ProcurarElemento(By.XPath("//button[.='Adicionar']")).Click();
                                 
            this.AguardarSegundos(3);

            this.SelectElemento(By.Id("repeatSelect"));

            this.AguardarSegundos(1);

            this.SelectElementoValor("4");

            this.AguardarSegundos(1);

            this.ProcurarElemento(By.XPath("//button[.='Salvar']")).Click();

            this.Fim();
        }




    }
}
