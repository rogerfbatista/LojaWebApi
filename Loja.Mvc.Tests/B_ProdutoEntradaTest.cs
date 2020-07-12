using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace Loja.Mvc.Tests
{
    [TestClass]
    public class B_ProdutoEntradaTest : BaseTest
    {
        public B_ProdutoEntradaTest():base(false)
        {

        }
        [TestMethod]
        public void C_Produto_Entrada_Salvar()
        {

            this.Login("visitante", "visitante");

            this.AguardarSegundos(4);

            this.ProcurarElemento(By.LinkText("Fornecedor")).Click();

            this.AguardarSegundos(2);

            this.ProcurarElemento(By.LinkText("Lista Entrada Produto")).Click();

            this.AguardarSegundos(3);

            this.ProcurarElemento(By.XPath("/html/body/div[2]/div/div[1]/div/div/a")).Click();

            this.ProcurarElemento(By.Id("txtfornecedor")).SendKeys("Nike");
            this.AguardarSegundos(2);
            this.ProcurarElemento(By.Id("txtfornecedor")).SendKeys(Keys.Backspace);
            this.AguardarSegundos(1);
            this.ProcurarElemento(By.PartialLinkText("Nike S A")).Click();
            
             this.ProcurarElemento(By.Name("notaFiscalId")).SendKeys("4755");

            this.ProcurarElemento(By.Name("dataEmissao")).SendKeys("10/07/2020");

            this.ProcurarElemento(By.Name("dataVencimento")).SendKeys("28/07/2020");

            this.ProcurarElemento(By.Id("txtProduto")).SendKeys("Tenis Vans");

            this.AguardarSegundos(2);

            this.ProcurarElemento(By.Id("txtProduto")).SendKeys(Keys.Backspace);

            this.AguardarSegundos(1);

            this.ProcurarElemento(By.PartialLinkText("Tenis Vans")).Click();

            this.ProcurarElemento(By.Name("quantidadeEntrada")).SendKeys("100");

            this.ProcurarElemento(By.Name("valorUnitario")).SendKeys("100");

            this.ProcurarElemento(By.XPath("/html/body/div[2]/div/div[1]/div/div/form/div[5]/div/button")).Click();
          
            this.AguardarSegundos(1);
           
            this.ProcurarElemento(By.XPath("/html/body/div[2]/div/div[1]/div/div/div[3]/div/button")).Click();
                      

            this.Fim();
        }





    }
}
