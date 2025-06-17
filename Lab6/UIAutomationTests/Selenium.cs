using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace UIAutomationTest
{
    public class Selenium
    {
        IWebDriver _driver;
        
        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
        }

        [Test]
        public void CrearNuevoPais_DeberiaAgregarFila()
        {
            // Arrange
            // Abre una nueva ventana
            var URL = "http://localhost:8080/";

            // Maximiza la pantalla
            _driver.Manage().Window.Maximize();

            // Act
            // Navega a la página que se necesita probar
            _driver.Navigate().GoToUrl(URL);

            // Hacer click en el botón "Agregar País"
            _driver.FindElement(By.CssSelector(".btn-outline-secondary")).Click();

            // Verificar que el formulario se haya cargado
            var tituloFormulario = _driver.FindElement(By.CssSelector("h3")).Text;
            Assert.AreEqual("Formulario de creación de países", tituloFormulario);

            // Llenar el formulario
            _driver.FindElement(By.Id("name")).SendKeys("Costa Rica");
            _driver.FindElement(By.Id("continente")).SendKeys("América");
            _driver.FindElement(By.Id("idioma")).SendKeys("Español");

            // Enviar el formulario
            _driver.FindElement(By.CssSelector(".btn-success")).Click();

            // Esperar
            System.Threading.Thread.Sleep(1000);

            // Verificar que Costa Rica aparece en la tabla
            var fila = _driver.FindElement(By.XPath("//tr[td[text()='Costa Rica']]"));
            Assert.IsNotNull(fila);
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Close();
        }
    }
}