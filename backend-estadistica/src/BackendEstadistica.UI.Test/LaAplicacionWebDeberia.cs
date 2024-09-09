
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace BackendEstadistica.UI.Test;

public class LaAplicacionWebDeberia
{

    private readonly IWebDriver _driver;

    public LaAplicacionWebDeberia()
    {
        // Inicializar ChromeDriver
        _driver = new ChromeDriver();
    }

    [Fact]
    public void MostrarBienvenida()
    {
        try
        {
            // Navegar a la URL de la aplicación web
            _driver.Navigate().GoToUrl("https://localhost:4200/");

            // Esperar hasta 15 segundos para que el título de la página sea el esperado
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
            wait.Until(driver => driver.Title == "ChachiData");

            // Verificar que el título es el esperado
            Assert.Equal("ChachiData", _driver.Title);
        }
        finally
        {
            // Cerrar el navegador después de la prueba
            _driver.Quit();
        }

    }

}