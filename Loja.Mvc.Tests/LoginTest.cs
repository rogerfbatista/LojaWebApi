using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace Loja.Mvc.Tests
{
    [TestClass]
    public class LoginTest : BaseTest
    {
        [TestMethod]
        public void Login_Sonic_Ti_Valido()
        {
            this.Login("visitante", "visitante");

            this.AguardarSegundos(2);

            var smallEletemnt = this.ProcurarMuitosElemento(By.TagName("small"))[1].Text;

            Assert.IsTrue(smallEletemnt.Equals("Logout"));

            this.Fim();
        }


        [TestMethod]
        public void Login_Sonic_Ti_InValido()
        {
            this.Login("visitante", "123456");

           this.AguardarSegundos(2);

            var smallEletemnt = this.ProcurarMuitosElemento(By.TagName("p"))[0].Text;

            Assert.IsTrue(smallEletemnt.Equals("User not found."));
            this.Fim();
        }
    }
}
