using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Tests.TestSelenium
{
    [TestFixture/*(Ignore = "true")*/]
    class HousesTest
    {
        string RutaGlobal = "https://localhost:44378/";
        ChromeOptions opciones = new ChromeOptions();
        [Test]
        public void HomeIndexTest()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = RutaGlobal;
            var pageId = navegador.FindElementById("Viewindex");
            var pageId2 = navegador.FindElementById("LayoutInitial");

            Assert.IsNotNull(pageId);
            Assert.IsNotNull(pageId2);
            navegador.Close();
        }
        [Test]
        public void HomeButtonIndexTest()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = RutaGlobal;
            navegador.FindElementById("ButtnInicio").Click();

            var pageId = navegador.FindElementById("Viewindex");
            var pageId2 = navegador.FindElementById("LayoutInitial");

            Assert.IsNotNull(pageId);
            Assert.IsNotNull(pageId2);
            navegador.Close();
        }
        [Test]
        public void HomeIndexBtnBuscarTest()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = RutaGlobal;
            navegador.FindElementById("ButtnInicio").Click();

            navegador.FindElementById("buttonBuscar").Click();

            var pageId = navegador.FindElementById("ViewBuscar");
            var pageId2 = navegador.FindElementById("LayoutInitial");

            Assert.IsNotNull(pageId);
            Assert.IsNotNull(pageId2);
            navegador.Close();
        }      
        [Test]
        public void HomeBttnAboutTest()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = RutaGlobal;
            navegador.FindElementById("ButtnAbout").Click();

            var pageId = navegador.FindElementById("ViewAbout");

            var pageId2 = navegador.FindElementById("LayoutInitial");
 
            Assert.IsNotNull(pageId);
            Assert.IsNotNull(pageId2);
            navegador.Close();
        }
        [Test]
        public void HomeButtnContactTest()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = RutaGlobal;
            navegador.FindElementById("ButtnContact").Click();

            var pageId = navegador.FindElementById("ViewContact");

            var pageId2 = navegador.FindElementById("LayoutInitial");
            Assert.IsNotNull(pageId);
            Assert.IsNotNull(pageId2);
            navegador.Close();
        }
        [Test]
        public void HomeButtnLoginTest()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = RutaGlobal;
            navegador.FindElementById("ButtnLogin").Click();
            WebDriverWait webDriverWait = new WebDriverWait(navegador, TimeSpan.FromSeconds(10));
           
            var pageId = navegador.FindElementById("modalLogin");

            var pageId2 = navegador.FindElementById("LayoutInitial");

            Assert.IsNotNull(pageId);
            Assert.IsNotNull(pageId2);
            navegador.Close();
        }
        [Test] 
        public void HomeButtnPublicarInmuebleTest()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = RutaGlobal;
            navegador.FindElementById("ButtnPublicarInmueble").Click();

            var pageId = navegador.FindElementById("ViewPlanes");
            var pageId2 = navegador.FindElementById("LayoutInitial");
            Assert.IsNotNull(pageId);
            Assert.IsNotNull(pageId2);
            navegador.Close();
        }
        [Test]
        public void HomeButtnRegistroTest()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = RutaGlobal;
            navegador.FindElementById("ButtnRegistro").Click();

            var pageId = navegador.FindElementById("ViewRegistroUser");
            var pageId2 = navegador.FindElementById("LayoutInitial");
            Assert.IsNotNull(pageId);
            Assert.IsNotNull(pageId2);
            navegador.Close();
        }
        [Test]
        public void BottonServiciosVentaTest()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = RutaGlobal;
            
            navegador.FindElementById("navbarDropdown").Click();
            navegador.FindElementById("bttnServiciosVenta").Click();
            var pageId = navegador.FindElementById("ViewBuscar");
            var pageId2 = navegador.FindElementById("LayoutAdmin");
            Assert.IsNotNull(pageId);
            Assert.IsNotNull(pageId2);
            navegador.Close();
        }
        [Test]
        public void BottonServiciosAlquilerTest()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = RutaGlobal;
           
            navegador.FindElementById("navbarDropdown").Click();
            navegador.FindElementById("bttnServiciosAlquiler").Click();
            var pageId = navegador.FindElementById("ViewBuscar");

            var pageId2 = navegador.FindElementById("LayoutAdmin");
            Assert.IsNotNull(pageId);
            Assert.IsNotNull(pageId2);
            navegador.Close();
        }
        [Test]
        public void HomeNextImagenCarrouselPrincipalTest()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = RutaGlobal;
            navegador.FindElementById("nextCarrouselPrincipal").Click();

            var pageId = navegador.FindElementById("imagen02");
            var pageId2 = navegador.FindElementById("LayoutInitial");
            Assert.IsNotNull(pageId);
            Assert.IsNotNull(pageId2);
            navegador.Close();
        }
        [Test]
        public void HomePrevImagenCarrouselPrincipalTest()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = RutaGlobal;
            navegador.FindElementById("nextCarrouselPrincipal").Click();

            var pageId = navegador.FindElementById("imagen03");
            var pageId2 = navegador.FindElementById("LayoutInitial");
            Assert.IsNotNull(pageId);
            Assert.IsNotNull(pageId2);
            navegador.Close();
        }
        [Test]
        public void HomeVerPrimerInmuebleTest()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = RutaGlobal;
            navegador.FindElementById("bttnVerInmueble1").Click();
      
            var pageId = navegador.FindElementById("ViewInmueble");
            var pageId2 = navegador.FindElementById("LayoutInitial");
            Assert.IsNotNull(pageId);
            Assert.IsNotNull(pageId2);
            navegador.Close();
        }

        /// <summary>
        /// admin
        /// </summary>
        [Test]
        public void LoginAdminTest() {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = RutaGlobal;
            navegador.FindElementById("ButtnLogin").Click();
            WebDriverWait webDriverWait = new WebDriverWait(navegador, TimeSpan.FromSeconds(5));
            webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.Id("Email")));
            navegador.FindElementById("Email").SendKeys("admin@admin.com");
            navegador.FindElementById("Password").SendKeys("admin");
            navegador.FindElementById("BottonIngresarLogin").Click();

            var pageId = navegador.FindElementById("LayoutAdmin");
             
            Assert.IsNotNull(pageId);
            navegador.Close();
        }
        [Test]
        public void HomeAdminButtonIndexTest()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = RutaGlobal;
            navegador.FindElementById("ButtnLogin").Click();
            WebDriverWait webDriverWait = new WebDriverWait(navegador, TimeSpan.FromSeconds(5));
            webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.Id("Email")));
            navegador.FindElementById("Email").SendKeys("admin@admin.com");
            navegador.FindElementById("Password").SendKeys("admin");
            navegador.FindElementById("BottonIngresarLogin").Click();
            navegador.FindElementById("btnInicio").Click();

            var pageId = navegador.FindElementById("Viewindex");
            var pageId2 = navegador.FindElementById("LayoutAdmin");

            Assert.IsNotNull(pageId);
            Assert.IsNotNull(pageId2);
            navegador.Close();
        }
        [Test]
        public void BottonRegistroAgenteTest()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = RutaGlobal;
            navegador.FindElementById("ButtnLogin").Click();
            WebDriverWait webDriverWait = new WebDriverWait(navegador, TimeSpan.FromSeconds(5));
            webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.Id("Email")));
            navegador.FindElementById("Email").SendKeys("admin@admin.com");
            navegador.FindElementById("Password").SendKeys("admin");
            navegador.FindElementById("BottonIngresarLogin").Click();
            navegador.FindElementById("btnRegistroAgente").Click();

            var pageId = navegador.FindElementById("ViewRegistroAgente");
            var pageId2 = navegador.FindElementById("LayoutAdmin");
            Assert.IsNotNull(pageId);
            Assert.IsNotNull(pageId2);
            navegador.Close();
        }
        [Test]
        public void BottonbtnRegistroInmuebleTest()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = RutaGlobal;
            navegador.FindElementById("ButtnLogin").Click();
            WebDriverWait webDriverWait = new WebDriverWait(navegador, TimeSpan.FromSeconds(5));
            webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.Id("Email")));
            navegador.FindElementById("Email").SendKeys("admin@admin.com");
            navegador.FindElementById("Password").SendKeys("admin");
            navegador.FindElementById("BottonIngresarLogin").Click();
            navegador.FindElementById("btnAddPublicacion").Click();

            var pageId = navegador.FindElementById("ViewAddPublicacion");
            var pageId2 = navegador.FindElementById("LayoutAdmin");
            Assert.IsNotNull(pageId);
            Assert.IsNotNull(pageId2);
            navegador.Close();
        }
        [Test]
        public void BottonbtnListaUsersTest()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = RutaGlobal;
            navegador.FindElementById("ButtnLogin").Click();
            WebDriverWait webDriverWait = new WebDriverWait(navegador, TimeSpan.FromSeconds(5));
            webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.Id("Email")));
            navegador.FindElementById("Email").SendKeys("admin@admin.com");
            navegador.FindElementById("Password").SendKeys("admin");
            navegador.FindElementById("BottonIngresarLogin").Click();
            navegador.FindElementById("btnListaUsers").Click();

            var pageId = navegador.FindElementById("ViewListaUsers");
            var pageId2 = navegador.FindElementById("LayoutAdmin");
            Assert.IsNotNull(pageId);
            Assert.IsNotNull(pageId2);
            navegador.Close();
        }
        [Test]
        public void BottonbtnListaAgentesTest()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = RutaGlobal;
            navegador.FindElementById("ButtnLogin").Click();
            WebDriverWait webDriverWait = new WebDriverWait(navegador, TimeSpan.FromSeconds(5));
            webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.Id("Email")));
            navegador.FindElementById("Email").SendKeys("admin@admin.com");
            navegador.FindElementById("Password").SendKeys("admin");
            navegador.FindElementById("BottonIngresarLogin").Click();
            navegador.FindElementById("btnListaAgentes").Click();

            var pageId = navegador.FindElementById("ViewListaAgentes");
            var pageId2 = navegador.FindElementById("LayoutAdmin");
            Assert.IsNotNull(pageId);
            Assert.IsNotNull(pageId2);
            navegador.Close();
        }
        [Test]
        public void BottonbtnListaPublicacionesTest()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = RutaGlobal;
            navegador.FindElementById("ButtnLogin").Click();
            WebDriverWait webDriverWait = new WebDriverWait(navegador, TimeSpan.FromSeconds(5));
            webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.Id("Email")));
            navegador.FindElementById("Email").SendKeys("admin@admin.com");
            navegador.FindElementById("Password").SendKeys("admin");
            navegador.FindElementById("BottonIngresarLogin").Click();
            navegador.FindElementById("btnListaPublicaciones").Click();

            var pageId = navegador.FindElementById("ViewListInmuebkes");
            var pageId2 = navegador.FindElementById("LayoutAdmin");
            Assert.IsNotNull(pageId);
            Assert.IsNotNull(pageId2);
            navegador.Close();
        }
        [Test]
        public void BottonAdminServiciosVentaTest()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = RutaGlobal;
            navegador.FindElementById("ButtnLogin").Click();
            WebDriverWait webDriverWait = new WebDriverWait(navegador, TimeSpan.FromSeconds(5));
            webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.Id("Email")));
            navegador.FindElementById("Email").SendKeys("admin@admin.com");
            navegador.FindElementById("Password").SendKeys("admin");
            navegador.FindElementById("BottonIngresarLogin").Click();
            navegador.FindElementById("navbarDropdown").Click();
            navegador.FindElementById("bttnServiciosVenta").Click();
            var pageId = navegador.FindElementById("ViewBuscar");
            var pageId2 = navegador.FindElementById("LayoutAdmin");
            Assert.IsNotNull(pageId);
            Assert.IsNotNull(pageId2);
            navegador.Close();
        }
        [Test]
        public void BottonAdminServiciosAlquilerTest()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = RutaGlobal;
            navegador.FindElementById("ButtnLogin").Click();
            WebDriverWait webDriverWait = new WebDriverWait(navegador, TimeSpan.FromSeconds(5));
            webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.Id("Email")));
            navegador.FindElementById("Email").SendKeys("admin@admin.com");
            navegador.FindElementById("Password").SendKeys("admin");
            navegador.FindElementById("BottonIngresarLogin").Click();
            navegador.FindElementById("navbarDropdown").Click();
            navegador.FindElementById("bttnServiciosAlquiler").Click();
            var pageId = navegador.FindElementById("ViewBuscar");

            var pageId2 = navegador.FindElementById("LayoutAdmin");
            Assert.IsNotNull(pageId);
            Assert.IsNotNull(pageId2);
            navegador.Close();
        }
        [Test]        
        public void BottonbttnCOnfiguracionUsuarioTest()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = RutaGlobal;
            navegador.FindElementById("ButtnLogin").Click();
            WebDriverWait webDriverWait = new WebDriverWait(navegador, TimeSpan.FromSeconds(5));
            webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.Id("Email")));
            navegador.FindElementById("Email").SendKeys("admin@admin.com");
            navegador.FindElementById("Password").SendKeys("admin");
            navegador.FindElementById("BottonIngresarLogin").Click();
            navegador.FindElementByClassName("bttnConfiguracionUsuario").Click();
            navegador.FindElementById("bttnCOnfiguracionUsuario").Click();

            var pageId = navegador.FindElementById("ViewGetUser");

            var pageId2 = navegador.FindElementById("LayoutAdmin");
            Assert.IsNotNull(pageId);
            Assert.IsNotNull(pageId2);
            navegador.Close();
        }
        [Test]
        public void HomeAdminNextImagenCarrouselPrincipalTest()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = RutaGlobal;
            navegador.FindElementById("ButtnLogin").Click();
            WebDriverWait webDriverWait = new WebDriverWait(navegador, TimeSpan.FromSeconds(5));
            webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.Id("Email")));
            navegador.FindElementById("Email").SendKeys("admin@admin.com");
            navegador.FindElementById("Password").SendKeys("admin");
            navegador.FindElementById("BottonIngresarLogin").Click();

            navegador.FindElementById("nextCarrouselPrincipal").Click();

            var pageId = navegador.FindElementById("imagen02");
            var pageId2 = navegador.FindElementById("LayoutAdmin");
            Assert.IsNotNull(pageId);
            Assert.IsNotNull(pageId2);
            navegador.Close();
        }
        [Test]
        public void HomeAdminPrevImagenCarrouselPrincipalTest()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = RutaGlobal;
            navegador.FindElementById("ButtnLogin").Click();
            WebDriverWait webDriverWait = new WebDriverWait(navegador, TimeSpan.FromSeconds(5));
            webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.Id("Email")));
            navegador.FindElementById("Email").SendKeys("admin@admin.com");
            navegador.FindElementById("Password").SendKeys("admin");
            navegador.FindElementById("BottonIngresarLogin").Click();

            navegador.FindElementById("nextCarrouselPrincipal").Click();

            var pageId = navegador.FindElementById("imagen03");
            var pageId2 = navegador.FindElementById("LayoutAdmin");
            Assert.IsNotNull(pageId);
            Assert.IsNotNull(pageId2);
            navegador.Close();
        }
        [Test]
        public void HomeAdminVerPrimerInmuebleTest()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = RutaGlobal;
            navegador.FindElementById("ButtnLogin").Click();
            WebDriverWait webDriverWait = new WebDriverWait(navegador, TimeSpan.FromSeconds(5));
            webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.Id("Email")));
            navegador.FindElementById("Email").SendKeys("admin@admin.com");
            navegador.FindElementById("Password").SendKeys("admin");
            navegador.FindElementById("BottonIngresarLogin").Click();
            navegador.FindElementById("bttnVerInmueble1").Click();

            var pageId = navegador.FindElementById("ViewInmueble");
            var pageId2 = navegador.FindElementById("LayoutAdmin");
            Assert.IsNotNull(pageId);
            Assert.IsNotNull(pageId2);
            navegador.Close();
        }
        [Test]
        public void BottonSalirTest()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = RutaGlobal;
            navegador.FindElementById("ButtnLogin").Click();
      
            WebDriverWait webDriverWait = new WebDriverWait(navegador,TimeSpan.FromSeconds(5));
            webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.Id("Email")));

            navegador.FindElementById("Email").SendKeys("admin@admin.com");
            navegador.FindElementById("Password").SendKeys("admin");
            navegador.FindElementById("BottonIngresarLogin").Click();
            navegador.FindElementByClassName("bttnConfiguracionUsuario").Click();
            navegador.FindElementByClassName("btnSalir").Click();

            var pageId = navegador.FindElementById("LayoutInitial");

            var pageId2 = navegador.FindElementById("LayoutAdmin");
            Assert.IsNotNull(pageId);
            Assert.IsNotNull(pageId2);
            navegador.Close();
        }
       
        /// <summary>
        /// Agente
        /// </summary>
        [Test]
        public void LoginAgenteTest()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = RutaGlobal;
            navegador.FindElementById("ButtnLogin").Click();

            WebDriverWait webDriverWait = new WebDriverWait(navegador, TimeSpan.FromSeconds(5));
            webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.Id("Email")));
            navegador.FindElementById("Email").SendKeys("agente@agente.com");
            navegador.FindElementById("Password").SendKeys("agente");
            navegador.FindElementById("BottonIngresarLogin").Click();

            var pageId = navegador.FindElementById("LayoutAgente");

            Assert.IsNotNull(pageId);
            navegador.Close();
        }
        [Test]
        public void AgenteButtonIndexTest()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = RutaGlobal;
            navegador.FindElementById("ButtnLogin").Click();
            WebDriverWait webDriverWait = new WebDriverWait(navegador, TimeSpan.FromSeconds(5));
            webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.Id("Email")));
            navegador.FindElementById("Email").SendKeys("agente@agente.com");
            navegador.FindElementById("Password").SendKeys("agente");
            navegador.FindElementById("BottonIngresarLogin").Click();
            navegador.FindElementById("btnInicio").Click();

            var pageId = navegador.FindElementById("Viewindex");
            var pageId2 = navegador.FindElementById("LayoutAgente");

            Assert.IsNotNull(pageId);
            Assert.IsNotNull(pageId2);
            navegador.Close();
        }
        [Test]
        public void AgenteButtonAboutTest()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = RutaGlobal;
            navegador.FindElementById("ButtnLogin").Click();
            WebDriverWait webDriverWait = new WebDriverWait(navegador, TimeSpan.FromSeconds(5));
            webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.Id("Email")));
            navegador.FindElementById("Email").SendKeys("agente@agente.com");
            navegador.FindElementById("Password").SendKeys("agente");
            navegador.FindElementById("BottonIngresarLogin").Click();
            navegador.FindElementById("btnAbout").Click();

            var pageId = navegador.FindElementById("ViewAbout");
            var pageId2 = navegador.FindElementById("LayoutAgente");

            Assert.IsNotNull(pageId);
            Assert.IsNotNull(pageId2);
            navegador.Close();
        }
        [Test]
        public void AgenteButtonContactTest()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = RutaGlobal;
            navegador.FindElementById("ButtnLogin").Click();
            WebDriverWait webDriverWait = new WebDriverWait(navegador, TimeSpan.FromSeconds(5));
            webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.Id("Email")));
            navegador.FindElementById("Email").SendKeys("agente@agente.com");
            navegador.FindElementById("Password").SendKeys("agente");
            navegador.FindElementById("BottonIngresarLogin").Click();
            navegador.FindElementById("btnContacto").Click();

            var pageId = navegador.FindElementById("ViewContact");
            var pageId2 = navegador.FindElementById("LayoutAgente");

            Assert.IsNotNull(pageId);
            Assert.IsNotNull(pageId2);
            navegador.Close();
        }
        [Test]
        public void BottonAgentebtnRegistroInmuebleTest()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = RutaGlobal;
            navegador.FindElementById("ButtnLogin").Click();
            WebDriverWait webDriverWait = new WebDriverWait(navegador, TimeSpan.FromSeconds(5));
            webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.Id("Email")));
            navegador.FindElementById("Email").SendKeys("agente@agente.com");
            navegador.FindElementById("Password").SendKeys("agente");
            navegador.FindElementById("BottonIngresarLogin").Click();

            navegador.FindElementById("btnAddPublicacion").Click();

            var pageId = navegador.FindElementById("ViewAddPublicacion");
            var pageId2 = navegador.FindElementById("LayoutAgente");
            Assert.IsNotNull(pageId);
            Assert.IsNotNull(pageId2);
            navegador.Close();
        }
        [Test]
        public void AgemteBottonListaPublicacionesTest()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = RutaGlobal;
            navegador.FindElementById("ButtnLogin").Click();
            WebDriverWait webDriverWait = new WebDriverWait(navegador, TimeSpan.FromSeconds(5));
            webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.Id("Email")));
            navegador.FindElementById("Email").SendKeys("agente@agente.com");
            navegador.FindElementById("Password").SendKeys("agente");
            navegador.FindElementById("BottonIngresarLogin").Click();
            navegador.FindElementById("btnMisPublicaciones").Click();

            var pageId = navegador.FindElementById("ViewListInmuebkes");
            var pageId2 = navegador.FindElementById("LayoutAgente");
            Assert.IsNotNull(pageId);
            Assert.IsNotNull(pageId2);
            navegador.Close();
        }
        [Test]
        public void BottonAgenteServiciosAlquilerTest()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = RutaGlobal;
            navegador.FindElementById("ButtnLogin").Click();
            WebDriverWait webDriverWait = new WebDriverWait(navegador, TimeSpan.FromSeconds(5));
            webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.Id("Email")));
            navegador.FindElementById("Email").SendKeys("agente@agente.com");
            navegador.FindElementById("Password").SendKeys("agente");
            navegador.FindElementById("BottonIngresarLogin").Click();
            navegador.FindElementById("navbarDropdown").Click();
            navegador.FindElementById("bttnServiciosAlquiler").Click();
            var pageId = navegador.FindElementById("ViewBuscar");

            var pageId2 = navegador.FindElementById("LayoutAgente");
            Assert.IsNotNull(pageId);
            Assert.IsNotNull(pageId2);
            navegador.Close();
        }
        [Test]
        public void BottonAgenteServiciosVentaTest()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = RutaGlobal;
            navegador.FindElementById("ButtnLogin").Click();
            WebDriverWait webDriverWait = new WebDriverWait(navegador, TimeSpan.FromSeconds(5));
            webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.Id("Email")));
            navegador.FindElementById("Email").SendKeys("agente@agente.com");
            navegador.FindElementById("Password").SendKeys("agente");
            navegador.FindElementById("BottonIngresarLogin").Click();
            navegador.FindElementById("navbarDropdown").Click();
            navegador.FindElementById("bttnServiciosVenta").Click();
            var pageId = navegador.FindElementById("ViewBuscar");

            var pageId2 = navegador.FindElementById("LayoutAgente");
            Assert.IsNotNull(pageId);
            Assert.IsNotNull(pageId2);
            navegador.Close();
        }
        [Test]
        public void BottonAgenteConfiguracionUsuarioTest()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = RutaGlobal;
            navegador.FindElementById("ButtnLogin").Click();
            WebDriverWait webDriverWait = new WebDriverWait(navegador, TimeSpan.FromSeconds(5));
            webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.Id("Email")));
            navegador.FindElementById("Email").SendKeys("agente@agente.com");
            navegador.FindElementById("Password").SendKeys("agente");
            navegador.FindElementById("BottonIngresarLogin").Click();
            navegador.FindElementByClassName("bttnConfiguracionUsuario").Click();
            navegador.FindElementById("bttnConfiguracionPerfil").Click();

            var pageId = navegador.FindElementById("ViewGetUser");

            var pageId2 = navegador.FindElementById("LayoutAgente");
            Assert.IsNotNull(pageId);
            Assert.IsNotNull(pageId2);
            navegador.Close();
        }
        [Test]
        public void HomeAgenteNextImagenCarrouselPrincipalTest()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = RutaGlobal;
            navegador.FindElementById("ButtnLogin").Click();
            WebDriverWait webDriverWait = new WebDriverWait(navegador, TimeSpan.FromSeconds(5));
            webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.Id("Email")));
            navegador.FindElementById("Email").SendKeys("agente@agente.com");
            navegador.FindElementById("Password").SendKeys("agente");
            navegador.FindElementById("BottonIngresarLogin").Click();

            navegador.FindElementById("nextCarrouselPrincipal").Click();

            var pageId = navegador.FindElementById("imagen02");
            var pageId2 = navegador.FindElementById("LayoutAgente");
            Assert.IsNotNull(pageId);
            Assert.IsNotNull(pageId2);
            navegador.Close();
        }
        [Test]
        public void HomeAgentePrevImagenCarrouselPrincipalTest()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = RutaGlobal;
            navegador.FindElementById("ButtnLogin").Click();
            WebDriverWait webDriverWait = new WebDriverWait(navegador, TimeSpan.FromSeconds(5));
            webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.Id("Email")));
            navegador.FindElementById("Email").SendKeys("agente@agente.com");
            navegador.FindElementById("Password").SendKeys("agente");
            navegador.FindElementById("BottonIngresarLogin").Click();

            navegador.FindElementById("nextCarrouselPrincipal").Click();

            var pageId = navegador.FindElementById("imagen03");
            var pageId2 = navegador.FindElementById("LayoutAgente");
            Assert.IsNotNull(pageId);
            Assert.IsNotNull(pageId2);
            navegador.Close();
        }
        [Test]
        public void HomeAgenteVerPrimerInmuebleTest()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = RutaGlobal;
            navegador.FindElementById("ButtnLogin").Click();
            WebDriverWait webDriverWait = new WebDriverWait(navegador, TimeSpan.FromSeconds(5));
            webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.Id("Email")));
            navegador.FindElementById("Email").SendKeys("agente@agente.com");
            navegador.FindElementById("Password").SendKeys("agente");
            navegador.FindElementById("BottonIngresarLogin").Click();
            navegador.FindElementById("bttnVerInmueble1").Click();

            var pageId = navegador.FindElementById("ViewInmueble");
            var pageId2 = navegador.FindElementById("LayoutAgente");
            Assert.IsNotNull(pageId);
            Assert.IsNotNull(pageId2);
            navegador.Close();
        }
        [Test]
        public void BottonAgenteSalirTest()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = RutaGlobal;
            navegador.FindElementById("ButtnLogin").Click();

            WebDriverWait webDriverWait = new WebDriverWait(navegador, TimeSpan.FromSeconds(5));
            webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.Id("Email")));

            navegador.FindElementById("Email").SendKeys("admin@admin.com");
            navegador.FindElementById("Password").SendKeys("admin");
            navegador.FindElementById("BottonIngresarLogin").Click();
            navegador.FindElementByClassName("bttnConfiguracionUsuario").Click();
            navegador.FindElementByClassName("btnSalir").Click();

            var pageId = navegador.FindElementById("LayoutInitial");
 
            Assert.IsNotNull(pageId);
     
            navegador.Close();
        }

        /// <summary>
        /// Usuario
        /// </summary>

        [Test]
        public void LoginUsuarioTest()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = RutaGlobal;
            navegador.FindElementById("ButtnLogin").Click();

            WebDriverWait webDriverWait = new WebDriverWait(navegador, TimeSpan.FromSeconds(5));
            webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.Id("Email")));
            navegador.FindElementById("Email").SendKeys("usuario@usuario.com");
            navegador.FindElementById("Password").SendKeys("usuario");
            navegador.FindElementById("BottonIngresarLogin").Click();

            var pageId = navegador.FindElementById("LayoutUsuario");

            Assert.IsNotNull(pageId);
            navegador.Close();
        }
        [Test]
        public void UserButtonIndexTest()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = RutaGlobal;
            navegador.FindElementById("ButtnLogin").Click();
            WebDriverWait webDriverWait = new WebDriverWait(navegador, TimeSpan.FromSeconds(5));
            webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.Id("Email")));
            navegador.FindElementById("Email").SendKeys("usuario@usuario.com");
            navegador.FindElementById("Password").SendKeys("usuario");
            navegador.FindElementById("BottonIngresarLogin").Click();
            navegador.FindElementById("btnInicio").Click();

            var pageId = navegador.FindElementById("Viewindex");
            var pageId2 = navegador.FindElementById("LayoutUsuario");

            Assert.IsNotNull(pageId);
            Assert.IsNotNull(pageId2);
            navegador.Close();
        }
        [Test]
        public void UserButtonAboutTest()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = RutaGlobal;
            navegador.FindElementById("ButtnLogin").Click();
            WebDriverWait webDriverWait = new WebDriverWait(navegador, TimeSpan.FromSeconds(5));
            webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.Id("Email")));
            navegador.FindElementById("Email").SendKeys("usuario@usuario.com");
            navegador.FindElementById("Password").SendKeys("usuario");
            navegador.FindElementById("BottonIngresarLogin").Click();
            navegador.FindElementById("btnAbout").Click();

            var pageId = navegador.FindElementById("ViewAbout");
            var pageId2 = navegador.FindElementById("LayoutUsuario");

            Assert.IsNotNull(pageId);
            Assert.IsNotNull(pageId2);
            navegador.Close();
        }
        [Test]
        public void UserButtonContactTest()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = RutaGlobal;
            navegador.FindElementById("ButtnLogin").Click();
            WebDriverWait webDriverWait = new WebDriverWait(navegador, TimeSpan.FromSeconds(5));
            webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.Id("Email")));
            navegador.FindElementById("Email").SendKeys("usuario@usuario.com");
            navegador.FindElementById("Password").SendKeys("usuario");
            navegador.FindElementById("BottonIngresarLogin").Click();
            navegador.FindElementById("btnContacto").Click();

            var pageId = navegador.FindElementById("ViewContact");
            var pageId2 = navegador.FindElementById("LayoutUsuario");

            Assert.IsNotNull(pageId);
            Assert.IsNotNull(pageId2);
            navegador.Close();
        }
        [Test]
        public void BottonusuarioRegistroInmuebleTest()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = RutaGlobal;
            navegador.FindElementById("ButtnLogin").Click();
            WebDriverWait webDriverWait = new WebDriverWait(navegador, TimeSpan.FromSeconds(5));
            webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.Id("Email")));
            navegador.FindElementById("Email").SendKeys("usuario@usuario.com");
            navegador.FindElementById("Password").SendKeys("usuario");
            navegador.FindElementById("BottonIngresarLogin").Click();

            navegador.FindElementById("btnAddPublicacion").Click();

            var pageId = navegador.FindElementById("ViewAddPublicacion");
            var pageId2 = navegador.FindElementById("LayoutUsuario");
            Assert.IsNotNull(pageId);
            Assert.IsNotNull(pageId2);
            navegador.Close();
        }
        [Test]
        public void usuarioBottonListaPublicacionesTest()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = RutaGlobal;
            navegador.FindElementById("ButtnLogin").Click();
            WebDriverWait webDriverWait = new WebDriverWait(navegador, TimeSpan.FromSeconds(5));
            webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.Id("Email")));
            navegador.FindElementById("Email").SendKeys("usuario@usuario.com");
            navegador.FindElementById("Password").SendKeys("usuario");
            navegador.FindElementById("BottonIngresarLogin").Click();
            navegador.FindElementById("btnListPublicacion").Click();

            var pageId = navegador.FindElementById("ViewListInmuebkes");
            var pageId2 = navegador.FindElementById("LayoutUsuario");
            Assert.IsNotNull(pageId);
            Assert.IsNotNull(pageId2);
            navegador.Close();
        }
        [Test]
        public void BottonusuarioServiciosAlquilerTest()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = RutaGlobal;
            navegador.FindElementById("ButtnLogin").Click();
            WebDriverWait webDriverWait = new WebDriverWait(navegador, TimeSpan.FromSeconds(5));
            webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.Id("Email")));
            navegador.FindElementById("Email").SendKeys("usuario@usuario.com");
            navegador.FindElementById("Password").SendKeys("usuario");
            navegador.FindElementById("BottonIngresarLogin").Click();

            navegador.FindElementByClassName("DesplegarOpcionesUsuario").Click();
            navegador.FindElementById("bttnServiciosAlquiler").Click();

            var pageId = navegador.FindElementById("ViewBuscar");

            var pageId2 = navegador.FindElementById("LayoutUsuario");
            Assert.IsNotNull(pageId);
            Assert.IsNotNull(pageId2);
            navegador.Close();
        }
        [Test]
        public void BottonusuarioServiciosVentaTest()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = RutaGlobal;
            navegador.FindElementById("ButtnLogin").Click();
            WebDriverWait webDriverWait = new WebDriverWait(navegador, TimeSpan.FromSeconds(5));
            webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.Id("Email")));
            navegador.FindElementById("Email").SendKeys("usuario@usuario.com");
            navegador.FindElementById("Password").SendKeys("usuario");
            navegador.FindElementById("BottonIngresarLogin").Click();
            navegador.FindElementByClassName("DesplegarOpcionesUsuario").Click();
            navegador.FindElementById("bttnServiciosVenta").Click();

            var pageId = navegador.FindElementById("ViewBuscar");

            var pageId2 = navegador.FindElementById("LayoutUsuario");
            Assert.IsNotNull(pageId);
            Assert.IsNotNull(pageId2);
            navegador.Close();
        }
        [Test]
        public void BottonusuarioConfiguracionUsuarioTest()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = RutaGlobal;
            navegador.FindElementById("ButtnLogin").Click();
            WebDriverWait webDriverWait = new WebDriverWait(navegador, TimeSpan.FromSeconds(5));
            webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.Id("Email")));
            navegador.FindElementById("Email").SendKeys("usuario@usuario.com");
            navegador.FindElementById("Password").SendKeys("usuario");
            navegador.FindElementById("BottonIngresarLogin").Click();
            navegador.FindElementByClassName("bttnConfiguracionUsuario").Click();
            navegador.FindElementById("bttnConfiguracionPerfil").Click();

            var pageId = navegador.FindElementById("ViewGetUser");

            var pageId2 = navegador.FindElementById("LayoutUsuario");
            Assert.IsNotNull(pageId);
            Assert.IsNotNull(pageId2);
            navegador.Close();
        }
        [Test]
        public void HomeusuarioNextImagenCarrouselPrincipalTest()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = RutaGlobal;
            navegador.FindElementById("ButtnLogin").Click();
            WebDriverWait webDriverWait = new WebDriverWait(navegador, TimeSpan.FromSeconds(5));
            webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.Id("Email")));
            navegador.FindElementById("Email").SendKeys("usuario@usuario.com");
            navegador.FindElementById("Password").SendKeys("usuario");
            navegador.FindElementById("BottonIngresarLogin").Click();

            navegador.FindElementById("nextCarrouselPrincipal").Click();

            var pageId = navegador.FindElementById("imagen02");
            var pageId2 = navegador.FindElementById("LayoutUsuario");
            Assert.IsNotNull(pageId);
            Assert.IsNotNull(pageId2);
            navegador.Close();
        }
        [Test]
        public void HomeusuarioPrevImagenCarrouselPrincipalTest()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = RutaGlobal;
            navegador.FindElementById("ButtnLogin").Click();
            WebDriverWait webDriverWait = new WebDriverWait(navegador, TimeSpan.FromSeconds(5));
            webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.Id("Email")));
            navegador.FindElementById("Email").SendKeys("usuario@usuario.com");
            navegador.FindElementById("Password").SendKeys("usuario");
            navegador.FindElementById("BottonIngresarLogin").Click();

            navegador.FindElementById("nextCarrouselPrincipal").Click();

            var pageId = navegador.FindElementById("imagen03");
            var pageId2 = navegador.FindElementById("LayoutUsuario");
            Assert.IsNotNull(pageId);
            Assert.IsNotNull(pageId2);
            navegador.Close();
        }
        [Test]
        public void HomeusuarioVerPrimerInmuebleTest()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = RutaGlobal;
            navegador.FindElementById("ButtnLogin").Click();
            WebDriverWait webDriverWait = new WebDriverWait(navegador, TimeSpan.FromSeconds(5));
            webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.Id("Email")));
            navegador.FindElementById("Email").SendKeys("usuario@usuario.com");
            navegador.FindElementById("Password").SendKeys("usuario");
            navegador.FindElementById("BottonIngresarLogin").Click();
            navegador.FindElementById("bttnVerInmueble1").Click();

            var pageId = navegador.FindElementById("ViewInmueble");
            var pageId2 = navegador.FindElementById("LayoutUsuario");
            Assert.IsNotNull(pageId);
            Assert.IsNotNull(pageId2);
            navegador.Close();
        }
        [Test]
        public void BottonusuarioSalirTest()
        {
            ChromeDriver navegador = new ChromeDriver();
            navegador.Url = RutaGlobal;
            navegador.FindElementById("ButtnLogin").Click();

            WebDriverWait webDriverWait = new WebDriverWait(navegador, TimeSpan.FromSeconds(5));
            webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.Id("Email")));

            navegador.FindElementById("Email").SendKeys("usuario@usuario.com");
            navegador.FindElementById("Password").SendKeys("usuario");
            navegador.FindElementById("BottonIngresarLogin").Click();
            navegador.FindElementByClassName("bttnConfiguracionUsuario").Click();
            navegador.FindElementById("btnSalir").Click();

            var pageId = navegador.FindElementById("LayoutInitial");

            Assert.IsNotNull(pageId);

            navegador.Close();
        }


    }
}
