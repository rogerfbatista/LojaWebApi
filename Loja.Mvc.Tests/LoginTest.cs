using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace Loja.Mvc.Tests
{
    [TestClass]
    public class LoginTest
    {
        [TestMethod]
        public void Login_Sonic_Ti_Valido()
        {
            //background
            //ChromeOptions option = new ChromeOptions();
            //option.AddArgument("--headless");
            //IWebDriver driver = new ChromeDriver(option);

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

            Thread.Sleep(TimeSpan.FromSeconds(2));

            var small = By.TagName("small");
            var smallEletemnt = driver.FindElements(small)[1].Text;

            Assert.IsTrue(smallEletemnt.Equals("Logout"));

            driver.Close();
            driver.Quit();
        }


        [TestMethod]
        public void Login_Sonic_Ti_InValido()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://www.sonic.somee.com/");
            driver.Manage().Window.Maximize();


            var name = By.TagName("input");
            var element = driver.FindElements(name);
            element[0].SendKeys(" visitante");
            element[1].SendKeys("123456");


            var btn = By.ClassName("btn-primary");
            var btnElement = driver.FindElement(btn);
            btnElement.Click();


            Thread.Sleep(TimeSpan.FromSeconds(2));

            var small = By.TagName("p");
            var smallEletemnt = driver.FindElements(small)[0].Text;

            Assert.IsTrue(smallEletemnt.Equals("User not found."));

            driver.Close();
            driver.Quit();
        }
    }
}
