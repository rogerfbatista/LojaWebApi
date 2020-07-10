using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using System.Windows.Forms;

namespace Loja.Mvc.Tests
{
    [TestClass]
    public class ProdutoTest
    {
        [TestMethod]
        public void Cadastro_Produto_A_Salvar()
        {

            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://www.sonic.somee.com/");
            driver.Manage().Window.Maximize();


            var name = By.TagName("input");
            var element = driver.FindElements(name);
            element[0].SendKeys(" visitante");
            element[1].SendKeys(" visitante");


            var btn = By.ClassName("btn-primary");

            var btnElement = driver.FindElement(btn);
            btnElement.Click();

            Thread.Sleep(TimeSpan.FromSeconds(4));


            var li = By.TagName("li");
            var liElement = driver.FindElements(li);
            liElement[24].Click();

            Thread.Sleep(TimeSpan.FromSeconds(1));
            liElement[29].Click();


            Thread.Sleep(TimeSpan.FromSeconds(3));

            driver.FindElement(By.XPath("//a[.='Novo Produto']")).Click();


            Thread.Sleep(TimeSpan.FromSeconds(2));

            var select = By.Id("repeatSelect");

            var driveselectElement = driver.FindElement(select);

            var selectElement = new SelectElement(driveselectElement);


            Thread.Sleep(TimeSpan.FromSeconds(2));

            selectElement.SelectByValue("6");


            driver.FindElement(By.Name("nomeProduto")).SendKeys("Tenis Vans");

            driver.FindElement(By.Name("codigoReferencia")).SendKeys("2513444");



            Thread.Sleep(TimeSpan.FromSeconds(2));

            IWebElement checkbx = driver.FindElement(By.Name("imagem"));

            Actions actions = new Actions(driver);
            actions = actions.MoveToElement(checkbx);
            actions = actions.Click();
            actions.Build().Perform();

            
            Thread.Sleep(TimeSpan.FromSeconds(3));
          
            SendKeys.SendWait(@"C:\Users\Bianca\TenisVans.jpg");

            Thread.Sleep(TimeSpan.FromSeconds(3));

            SendKeys.SendWait("{ENTER}");


            Thread.Sleep(TimeSpan.FromSeconds(1));

            driver.FindElement(By.XPath("//button[.='Adicionar']")).Click();

            Thread.Sleep(TimeSpan.FromSeconds(3));
            driver.Close();
            driver.Quit();
        }


        [TestMethod]
        public void Cadastro_Produto_B_Alterar()
        {

            IWebDriver driver = new ChromeDriver();
            //  driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            driver.Navigate().GoToUrl("http://www.sonic.somee.com/");
            driver.Manage().Window.Maximize();


            var name = By.TagName("input");
            var element = driver.FindElements(name);
            element[0].SendKeys(" visitante");
            element[1].SendKeys(" visitante");


            var btn = By.ClassName("btn-primary");

            var btnElement = driver.FindElement(btn);
            btnElement.Click();

            Thread.Sleep(TimeSpan.FromSeconds(3));


            var li = By.TagName("li");
            var liElement = driver.FindElements(li);
            liElement[24].Click();

            Thread.Sleep(TimeSpan.FromSeconds(1));
            liElement[29].Click();


            Thread.Sleep(TimeSpan.FromSeconds(3));

            driver.FindElement(By.XPath("//input[@data-ng-model='searchText']")).SendKeys("Tenis");


            Thread.Sleep(TimeSpan.FromSeconds(2));


            driver.FindElement(By.ClassName("glyphicon-pencil")).Click();

            Thread.Sleep(TimeSpan.FromSeconds(1));

            driver.FindElement(By.Name("nomeProduto")).Clear();

            driver.FindElement(By.Name("nomeProduto")).SendKeys("Tenis Vans 38-40");

            
            driver.FindElement(By.Name("codigoReferencia")).Clear();

            driver.FindElement(By.Name("codigoReferencia")).SendKeys("123456");

            Thread.Sleep(TimeSpan.FromSeconds(1));


            driver.FindElement(By.XPath("//button[.='Alterar']")).Click();

            Thread.Sleep(TimeSpan.FromSeconds(2));
            driver.Close();
            driver.Quit();
        }

        [TestMethod]
        public void Cadastro_Produto_C_Excluir()
        {

            IWebDriver driver = new ChromeDriver();
            //  driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            driver.Navigate().GoToUrl("http://www.sonic.somee.com/");
            driver.Manage().Window.Maximize();


            var name = By.TagName("input");
            var element = driver.FindElements(name);
            element[0].SendKeys(" visitante");
            element[1].SendKeys(" visitante");


            var btn = By.ClassName("btn-primary");

            var btnElement = driver.FindElement(btn);
            btnElement.Click();

            Thread.Sleep(TimeSpan.FromSeconds(4));


            var li = By.TagName("li");
            var liElement = driver.FindElements(li);
            liElement[24].Click();

            Thread.Sleep(TimeSpan.FromSeconds(1));
            liElement[29].Click();


            Thread.Sleep(TimeSpan.FromSeconds(3));

            driver.FindElement(By.XPath("//input[@data-ng-model='searchText']")).SendKeys("Tenis");


            Thread.Sleep(TimeSpan.FromSeconds(2));


            driver.FindElement(By.ClassName("glyphicon-remove-circle")).Click();

            Thread.Sleep(TimeSpan.FromSeconds(1));


            driver.FindElement(By.XPath("//button[.='Confirmar']")).Click();

            Thread.Sleep(TimeSpan.FromSeconds(2));
            driver.Close();
            driver.Quit();
        }


    }
}
