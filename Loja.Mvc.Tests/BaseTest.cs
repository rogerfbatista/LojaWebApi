using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Windows.Forms;

namespace Loja.Mvc.Tests
{
    public abstract class BaseTest
    {


        protected readonly IWebDriver _driver;
        public string _url { get; }

        private SelectElement _selectElement;
        public BaseTest(bool backGround)
        {
            // _url = "http://www.sonic.somee.com/";
            _url = "http://localhost/index.html";

            ChromeOptions option = new ChromeOptions();
            if (backGround)
                option.AddArgument("--headless");

            _driver = new ChromeDriver(option);
        }


        [TestInitialize]
        public void Inicializar()
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            _driver.Navigate().GoToUrl(this._url);
            _driver.Manage().Window.Maximize();
         
           

        }

        public IWebElement ProcurarElemento(By id)
        {
            return _driver.FindElement(id);
        }

        public bool ExisteElemento(By id)
        {
            try
            {
                this.ProcurarElemento(id);
                return false;
            }
            catch (NoSuchElementException)
            {
                return true;
            }
        }

      


        public ReadOnlyCollection<IWebElement> ProcurarMuitosElemento(By id)
        {
            return _driver.FindElements(id);
        }

        public void AguardarSegundos(int tempo)
        {
            Thread.Sleep(TimeSpan.FromSeconds(tempo));
        }

        public void SelectElemento(By id)
        {
            var elemento = this.ProcurarElemento(id);
            _selectElement = new SelectElement(elemento);
        }
        public void SelectElementoValor(string valor)
        {
            _selectElement.SelectByValue(valor);
        }

        public void SelectElementoTexto(string valor)
        {
            _selectElement.SelectByText(valor);
        }

        public void EscolherArquivoImportacao(By id, string arquivo)
        {
            var eleme = this.ProcurarElemento(id);
            Actions actions = new Actions(_driver);
            actions = actions.MoveToElement(eleme);
            actions = actions.Click();
            actions.Build().Perform();

            this.AguardarSegundos(3);

            SendKeys.SendWait(arquivo);

            this.AguardarSegundos(3);

            SendKeys.SendWait("{ENTER}");
        }

        public void Fim()
        {
            this.AguardarSegundos(5);
            _driver.Close();
            _driver.Quit();
        }

        public void Login(string email, string senha)
        {
            var name = By.TagName("input");
            var element = this.ProcurarMuitosElemento(name);

            element[0].SendKeys(email);
            element[1].SendKeys(senha);

            this.ProcurarElemento(By.XPath("//button[.='Sign in']")).Click();

            //var js = (IJavaScriptExecutor)_driver;
            //js.ExecuteScript("document.body.style.zoom='90%'");

        }
    }
}