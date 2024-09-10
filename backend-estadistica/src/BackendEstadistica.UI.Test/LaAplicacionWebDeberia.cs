using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace BackendEstadistica.UI.Test
{
    public class LaAplicacionWebDeberia
    {
        private readonly IWebDriver _driver;

        public LaAplicacionWebDeberia()
        {
            _driver = new ChromeDriver();
        }

        [Fact]
        public void MostrarBienvenida()
        {
            _driver.Navigate().GoToUrl("https://localhost:4200/");

            // Esperar hasta 15 segundos para que el título de la página sea el esperado
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            wait.Until(driver => driver.Title == "ClientesEstadisticaApp");

            // Verificar que el título es el esperado
            Assert.Equal("ClientesEstadisticaApp", _driver.Title);

            _driver.Quit();
        }
    }
}