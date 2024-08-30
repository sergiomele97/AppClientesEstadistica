using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BackendEstadistica.UI.Test
{
    public class LaAplicacionWebDeberia
    {

        private readonly IWebDriver _driver;

        public LaAplicacionWebDeberia(IWebDriver driver)
        {
            _driver = new ChromeDriver();
        }

        [Fact]
        public void MostrarBienvenida()
        {

            _driver.Navigate().GoToUrl("https://localhost:4200/");
            Assert.Equal("ClientesEstadisticaApp", _driver.Title);
         
            _driver.Quit();

        }
    }
}