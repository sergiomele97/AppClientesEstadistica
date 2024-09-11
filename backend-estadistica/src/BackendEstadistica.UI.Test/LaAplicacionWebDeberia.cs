using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace BackendEstadistica.UI.Test
{
    public class LaAplicacionWebDeberia
    {
        //private readonly IWebDriver _driver;

        //public LaAplicacionWebDeberia()
        //{
        //    var chromeOptions = new ChromeOptions();
        //    chromeOptions.AcceptInsecureCertificates = true; 
        //    chromeOptions.AddArgument("--headless"); // Ejecutar Chrome en modo sin cabeza
        //    chromeOptions.AddArgument("--disable-gpu"); // Deshabilitar GPU, útil para algunos sistemas
        //    chromeOptions.AddArgument("--no-sandbox"); // Necesario para algunos entornos


        //    _driver = new ChromeDriver(chromeOptions);
        //}

        //[Fact]
        //public void MostrarBienvenida()
        //{
        //    try
        //    {
        //        _driver.Navigate().GoToUrl("http://localhost:4200/");

        //        WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
        //        wait.Until(driver => driver.Title == "ChachiData");

        //        Assert.Equal("ChachiData", _driver.Title);
        //    }
        //    finally
        //    {
        //        Thread.Sleep(5000); 
        //        _driver.Quit(); 
        //    }
        //}

        //[Fact]
        //public void IniciarSesion()
        //{
        //        _driver.Navigate().GoToUrl("http://localhost:4200/login");

        //        IWebElement usuarioInput = _driver.FindElement(By.Name("username"));
        //        IWebElement passwordInput = _driver.FindElement(By.Name("password"));
        //        IWebElement loginButton = _driver.FindElement(By.Name("inicarSesion"));

        //        usuarioInput.SendKeys("chachidata1@gmail.com");
        //        passwordInput.SendKeys("c12345678*C");

        //        loginButton.Click();

        //        WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
        //        wait.Until(driver => driver.Url.Contains("/estadistica"));

        //        Assert.Contains("/estadistica", _driver.Url);        
        //}

        //[Fact]
        //public void ResolucionOutliers()
        //{
        //    try
        //    {

        //        IniciarSesion();
        //        _driver.Navigate().GoToUrl("http://localhost:4200/estadistica/outliers");

        //        IWebElement outlierResuelto = _driver.FindElement(By.Name("resolver"));
        //        outlierResuelto.Click();

   
        //        WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        //        IWebElement alertaResuelto = wait.Until(driver => driver.FindElement(By.Name("alertaResuelto")));

        //        Assert.True(alertaResuelto.Displayed, "La alerta no está visible.");
        //        Assert.Contains("Outlier Eliminado", alertaResuelto.Text);
        //    }
        //    finally
        //    {
        //        Thread.Sleep(5000);
        //        _driver.Quit();
        //    }
        //}


    }
}
