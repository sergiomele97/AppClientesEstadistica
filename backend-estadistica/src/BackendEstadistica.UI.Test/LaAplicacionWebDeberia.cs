using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace BackendEstadistica.UI.Test
{
    public class LaAplicacionWebDeberia
    {
        private readonly IWebDriver _driver;

        public LaAplicacionWebDeberia()
        {
            // Configurar ChromeDriver con opciones
            var chromeOptions = new ChromeOptions();
            chromeOptions.AcceptInsecureCertificates = true; // Aceptar certificados inseguros
            chromeOptions.AddArgument("--ignore-certificate-errors"); // Ignorar errores de certificado
            chromeOptions.AddArgument("--allow-insecure-localhost"); // Permitir conexiones inseguras a localhost

            _driver = new ChromeDriver(chromeOptions);
        }

        [Fact]
        public void MostrarBienvenida()
        {
            try
            {
                _driver.Navigate().GoToUrl("http://localhost:4200/");

                WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
                wait.Until(driver => driver.Title == "ChachiData");

                Assert.Equal("ChachiData", _driver.Title);
            }
            finally
            {
                Thread.Sleep(5000); // Espera antes de cerrar el navegador para ver el resultado
                _driver.Quit(); // Cerrar el navegador
            }
        }

        [Fact]
        public void IniciarSesion()
        {
            try
            {
                _driver.Navigate().GoToUrl("http://localhost:4200/login");

                IWebElement usuarioInput = _driver.FindElement(By.Name("username"));
                IWebElement passwordInput = _driver.FindElement(By.Name("password"));
                IWebElement loginButton = _driver.FindElement(By.Name("inicarSesion"));

                usuarioInput.SendKeys("chachidata1@gmail.com");
                passwordInput.SendKeys("c12345678*C");

                loginButton.Click();

                WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
                wait.Until(driver => driver.Url.Contains("/estadistica"));

                Assert.Contains("/estadistica", _driver.Url);
            }
            finally
            {
                Thread.Sleep(5000); // Espera antes de cerrar el navegador para ver el resultado
                _driver.Quit(); // Cerrar el navegador
            }
        }
    }
}
