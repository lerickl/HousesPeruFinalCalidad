using HousesPeru.Controllers;
using HousesPeru.Models;
using HousesPeru.services;
using HousesPeru.validaciones;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Tests.TestControllers
{
    [TestFixture]
    class InmuebleControllerTest
    {
        [Test]
        public void GetInmueblesIsOk()
        {
 
            var IAuthServiceMock = new Mock<IAuthService>();
            var IInmuebleServiceMock = new Mock<IInmuebleService>();
            var IImageServiceMock = new Mock<IImageService>();
            var IInmuebleTipoServiceMock = new Mock<IInmuebleTipoService>();
            var ICiudadServiceMock = new Mock<ICiudadService>();
            var IUsuarioServiceMock = new Mock<IUsuarioService>();

            var IPublicacionServiceMock = new Mock<IPublicacionService>();

            var IPlanServiceMock = new Mock<IPlanService>();

            var IValidacionInmuebleMock = new Mock<IValidacionInmueble>();
         

            var inmueble = new InmuebleController(IAuthServiceMock.Object, IInmuebleServiceMock.Object, IImageServiceMock.Object, IInmuebleTipoServiceMock.Object, ICiudadServiceMock.Object, IUsuarioServiceMock.Object, IPublicacionServiceMock.Object, IPlanServiceMock.Object, IValidacionInmuebleMock.Object);

            //var inmuebles = IInmuebleServiceMock.Setup(x=>x.GetInmubles()).Returns(new List<Inmueble>());
            var result = inmueble.GetInmuebles() as ViewResult;

            Assert.IsInstanceOf<ViewResult>(result);
            Assert.IsNull(result.ViewBag.UserLogged);
 
        }
        [Test]
        public void GetInmueblesADMINIsOk()
        {

            var IAuthServiceMock = new Mock<IAuthService>();
            var IInmuebleServiceMock = new Mock<IInmuebleService>();
            var IImageServiceMock = new Mock<IImageService>();
            var IInmuebleTipoServiceMock = new Mock<IInmuebleTipoService>();
            var ICiudadServiceMock = new Mock<ICiudadService>();
            var IUsuarioServiceMock = new Mock<IUsuarioService>();
            var IPublicacionServiceMock = new Mock<IPublicacionService>();
            var IPlanServiceMock = new Mock<IPlanService>();
            var IValidacionInmuebleMock = new Mock<IValidacionInmueble>();
 

            var temp = new Usuario()
            {
                Nombre = "Erick",
                TipoUsuario = "ADMINISTRADOR"
            };
            IAuthServiceMock.Setup(x=>x.GetLogedUser()).Returns(temp);
            IUsuarioServiceMock.Setup(x => x.GetAllUsers()).Returns(new List<Usuario>());
            IInmuebleServiceMock.Setup(x=>x.GetInmubles()).Returns(new List<Inmueble>());
            IInmuebleTipoServiceMock.Setup(x => x.getInmuebleTipos()).Returns(new List<InmuebleTipo>());
            ICiudadServiceMock.Setup(x => x.GetCiudades()).Returns(new List<Ciudades>());
            IPlanServiceMock.Setup(x => x.getPlans()).Returns(new List<Plan>());

            var inmueble = new InmuebleController(IAuthServiceMock.Object, IInmuebleServiceMock.Object, IImageServiceMock.Object, IInmuebleTipoServiceMock.Object, ICiudadServiceMock.Object, IUsuarioServiceMock.Object, IPublicacionServiceMock.Object, IPlanServiceMock.Object, IValidacionInmuebleMock.Object);

           var result = inmueble.GetInmuebles() as ViewResult;

            Assert.IsInstanceOf<ViewResult>(result);
            Assert.AreEqual(result.ViewBag.UserLogged, "ADMINISTRADOR");
            Assert.AreEqual(result.ViewBag.Usuarios, new List<Usuario>());
            Assert.AreEqual(result.ViewBag.Inmuebles, new List<Inmueble>());
            Assert.AreEqual(result.ViewBag.TipoInmueble, new List<InmuebleTipo>());
            Assert.AreEqual(result.ViewBag.Ciudad, new List<Ciudades>());
            Assert.AreEqual(result.ViewBag.Plan, new List<Plan>());


        }
        [Test]
        public void GetInmueblesAGENTEIsOk()
        {

            var IAuthServiceMock = new Mock<IAuthService>();
            var IInmuebleServiceMock = new Mock<IInmuebleService>();
            var IImageServiceMock = new Mock<IImageService>();
            var IInmuebleTipoServiceMock = new Mock<IInmuebleTipoService>();
            var ICiudadServiceMock = new Mock<ICiudadService>();
            var IUsuarioServiceMock = new Mock<IUsuarioService>();
            var IPublicacionServiceMock = new Mock<IPublicacionService>();
            var IPlanServiceMock = new Mock<IPlanService>();
            var IValidacionInmuebleMock = new Mock<IValidacionInmueble>();

            var temp = new Usuario()
            {
                Nombre = "Erick",
                TipoUsuario = "AGENTE"
            };
            IAuthServiceMock.Setup(x => x.GetLogedUser()).Returns(temp);
            IUsuarioServiceMock.Setup(x => x.GetAllUsers()).Returns(new List<Usuario>());
            IInmuebleServiceMock.Setup(x => x.GetInmubles()).Returns(new List<Inmueble>());
            IInmuebleTipoServiceMock.Setup(x => x.getInmuebleTipos()).Returns(new List<InmuebleTipo>());
            ICiudadServiceMock.Setup(x => x.GetCiudades()).Returns(new List<Ciudades>());
            IPlanServiceMock.Setup(x => x.getPlans()).Returns(new List<Plan>());

            var inmueble = new InmuebleController(IAuthServiceMock.Object, IInmuebleServiceMock.Object, IImageServiceMock.Object, IInmuebleTipoServiceMock.Object, ICiudadServiceMock.Object, IUsuarioServiceMock.Object, IPublicacionServiceMock.Object, IPlanServiceMock.Object, IValidacionInmuebleMock.Object);

           var result = inmueble.GetInmuebles() as ViewResult;

            Assert.IsInstanceOf<ViewResult>(result);
            Assert.AreEqual(result.ViewBag.UserLogged, "AGENTE");
            Assert.AreEqual(result.ViewBag.Usuarios, new List<Usuario>());
            Assert.AreEqual(result.ViewBag.Inmuebles, new List<Inmueble>());
            Assert.AreEqual(result.ViewBag.TipoInmueble, new List<InmuebleTipo>());
            Assert.AreEqual(result.ViewBag.Ciudad, new List<Ciudades>());
            Assert.AreEqual(result.ViewBag.Plan, new List<Plan>());

        }
        [Test]
        public void GetInmueblesUSUARIOIsOk()
        {

            var IAuthServiceMock = new Mock<IAuthService>();
            var IInmuebleServiceMock = new Mock<IInmuebleService>();
            var IImageServiceMock = new Mock<IImageService>();
            var IInmuebleTipoServiceMock = new Mock<IInmuebleTipoService>();
            var ICiudadServiceMock = new Mock<ICiudadService>();
            var IUsuarioServiceMock = new Mock<IUsuarioService>();
            var IPublicacionServiceMock = new Mock<IPublicacionService>();
            var IPlanServiceMock = new Mock<IPlanService>();
            var IValidacionInmuebleMock = new Mock<IValidacionInmueble>();

            var temp = new Usuario()
            {
                Nombre = "Erick",
                TipoUsuario = "USUARIO"
            };
            IAuthServiceMock.Setup(x => x.GetLogedUser()).Returns(temp);
            IUsuarioServiceMock.Setup(x => x.GetAllUsers()).Returns(new List<Usuario>());
            IInmuebleServiceMock.Setup(x => x.GetInmubles()).Returns(new List<Inmueble>());
            IInmuebleTipoServiceMock.Setup(x => x.getInmuebleTipos()).Returns(new List<InmuebleTipo>());
            ICiudadServiceMock.Setup(x => x.GetCiudades()).Returns(new List<Ciudades>());
            IPlanServiceMock.Setup(x => x.getPlans()).Returns(new List<Plan>());

            var inmueble = new InmuebleController(IAuthServiceMock.Object, IInmuebleServiceMock.Object, IImageServiceMock.Object, IInmuebleTipoServiceMock.Object, ICiudadServiceMock.Object, IUsuarioServiceMock.Object, IPublicacionServiceMock.Object, IPlanServiceMock.Object, IValidacionInmuebleMock.Object);

            var result = inmueble.GetInmuebles() as ViewResult;

            Assert.IsInstanceOf<ViewResult>(result);
            Assert.AreEqual(result.ViewBag.UserLogged, "USUARIO");
            Assert.AreEqual(result.ViewBag.Usuarios, new List<Usuario>());
            Assert.AreEqual(result.ViewBag.Inmuebles, new List<Inmueble>());
            Assert.AreEqual(result.ViewBag.TipoInmueble, new List<InmuebleTipo>());
            Assert.AreEqual(result.ViewBag.Ciudad, new List<Ciudades>());
            Assert.AreEqual(result.ViewBag.Plan, new List<Plan>());

        }

        [Test]
        public void GetBuscarIsOk()
        { 
            var IAuthServiceMock = new Mock<IAuthService>();
            var IInmuebleServiceMock = new Mock<IInmuebleService>();
            var IImageServiceMock = new Mock<IImageService>();
            var IInmuebleTipoServiceMock = new Mock<IInmuebleTipoService>();
            var ICiudadServiceMock = new Mock<ICiudadService>();
            var IUsuarioServiceMock = new Mock<IUsuarioService>();
            var IPublicacionServiceMock = new Mock<IPublicacionService>();
            var IPlanServiceMock = new Mock<IPlanService>();
            var IValidacionInmuebleMock = new Mock<IValidacionInmueble>();


            var inmueble = new InmuebleController(IAuthServiceMock.Object, IInmuebleServiceMock.Object, IImageServiceMock.Object, IInmuebleTipoServiceMock.Object, ICiudadServiceMock.Object, IUsuarioServiceMock.Object, IPublicacionServiceMock.Object, IPlanServiceMock.Object, IValidacionInmuebleMock.Object);

            var result = inmueble.Buscar("Alquiler") as ViewResult;

            Assert.IsInstanceOf<ViewResult>(result);
            Assert.IsNull(result.ViewBag.UserLogged);

 
        }
        [Test]
        public void GetBuscarWithADMINIsOk()
        {
            var IAuthServiceMock = new Mock<IAuthService>();
            var IInmuebleServiceMock = new Mock<IInmuebleService>();
            var IImageServiceMock = new Mock<IImageService>();
            var IInmuebleTipoServiceMock = new Mock<IInmuebleTipoService>();
            var ICiudadServiceMock = new Mock<ICiudadService>();
            var IUsuarioServiceMock = new Mock<IUsuarioService>();
            var IPublicacionServiceMock = new Mock<IPublicacionService>();
            var IPlanServiceMock = new Mock<IPlanService>();
            var IValidacionInmuebleMock = new Mock<IValidacionInmueble>();
            var temp = new Usuario()
            {
                Nombre = "Erick",
                TipoUsuario = "ADMINISTRADOR"
            };
           
            IAuthServiceMock.Setup(X => X.GetLogedUser()).Returns(temp);
            IInmuebleServiceMock.Setup(X => X.BuscarInmueble(0,0,"Venta")).Returns(new List<Inmueble>());
            IImageServiceMock.Setup(x => x.GetImagenes()).Returns(new List<Imagen>());
            IInmuebleTipoServiceMock.Setup(x=>x.getInmuebleTipos()).Returns(new List<InmuebleTipo>());
            ICiudadServiceMock.Setup(x => x.GetCiudades()).Returns(new List<Ciudades>());
            var inmueble = new InmuebleController(IAuthServiceMock.Object, IInmuebleServiceMock.Object, IImageServiceMock.Object, IInmuebleTipoServiceMock.Object, ICiudadServiceMock.Object, IUsuarioServiceMock.Object, IPublicacionServiceMock.Object, IPlanServiceMock.Object, IValidacionInmuebleMock.Object);

            var result = inmueble.Buscar("Venta") as ViewResult;

            Assert.IsInstanceOf<ViewResult>(result);
            Assert.AreEqual(result.ViewBag.UserLogged, "ADMINISTRADOR");
            Assert.AreEqual(result.ViewBag.Inmuebles, new List<Inmueble>());
            Assert.AreEqual(result.ViewBag.Imagenes, new List<Imagen>());
            Assert.AreEqual(result.ViewBag.TipoInmueble, new List<InmuebleTipo>());
            Assert.AreEqual(result.ViewBag.ciudad, new List<Ciudades>());
        }
        [Test]
        public void GetBuscarWithAgenteIsOk()
        {
            var IAuthServiceMock = new Mock<IAuthService>();
            var IInmuebleServiceMock = new Mock<IInmuebleService>();
            var IImageServiceMock = new Mock<IImageService>();
            var IInmuebleTipoServiceMock = new Mock<IInmuebleTipoService>();
            var ICiudadServiceMock = new Mock<ICiudadService>();
            var IUsuarioServiceMock = new Mock<IUsuarioService>();
            var IPublicacionServiceMock = new Mock<IPublicacionService>();
            var IPlanServiceMock = new Mock<IPlanService>();
            var IValidacionInmuebleMock = new Mock<IValidacionInmueble>();
            var temp = new Usuario()
            {
                Nombre = "Erick",
                TipoUsuario = "AGENTE"
            };
            IAuthServiceMock.Setup(X => X.GetLogedUser()).Returns(temp);
            IInmuebleServiceMock.Setup(X => X.BuscarInmueble(0, 0, "Venta")).Returns(new List<Inmueble>());
            IImageServiceMock.Setup(x => x.GetImagenes()).Returns(new List<Imagen>());
            IInmuebleTipoServiceMock.Setup(x => x.getInmuebleTipos()).Returns(new List<InmuebleTipo>());
            ICiudadServiceMock.Setup(x => x.GetCiudades()).Returns(new List<Ciudades>());

            var inmueble = new InmuebleController(IAuthServiceMock.Object, IInmuebleServiceMock.Object, IImageServiceMock.Object, IInmuebleTipoServiceMock.Object, ICiudadServiceMock.Object, IUsuarioServiceMock.Object, IPublicacionServiceMock.Object, IPlanServiceMock.Object, IValidacionInmuebleMock.Object);

            var result = inmueble.Buscar("Alquiler") as ViewResult;

            Assert.IsInstanceOf<ViewResult>(result);
            Assert.AreEqual(result.ViewBag.UserLogged, "AGENTE");
            Assert.AreEqual(result.ViewBag.Inmuebles, new List<Inmueble>());
            Assert.AreEqual(result.ViewBag.Imagenes, new List<Imagen>());
            Assert.AreEqual(result.ViewBag.TipoInmueble, new List<InmuebleTipo>());
            Assert.AreEqual(result.ViewBag.ciudad, new List<Ciudades>());


        }
        [Test]
        public void GetBuscarWithUsuarioIsOk()
        {
            var IAuthServiceMock = new Mock<IAuthService>();
            var IInmuebleServiceMock = new Mock<IInmuebleService>();
            var IImageServiceMock = new Mock<IImageService>();
            var IInmuebleTipoServiceMock = new Mock<IInmuebleTipoService>();
            var ICiudadServiceMock = new Mock<ICiudadService>();
            var IUsuarioServiceMock = new Mock<IUsuarioService>();
            var IPublicacionServiceMock = new Mock<IPublicacionService>();
            var IPlanServiceMock = new Mock<IPlanService>();
            var IValidacionInmuebleMock = new Mock<IValidacionInmueble>();
            var temp = new Usuario()
            {
                Nombre = "Erick",
                TipoUsuario = "USUARIO"
            };
            IAuthServiceMock.Setup(X => X.GetLogedUser()).Returns(temp);
            IInmuebleServiceMock.Setup(X => X.BuscarInmueble(0, 0, "Venta")).Returns(new List<Inmueble>());
            IImageServiceMock.Setup(x => x.GetImagenes()).Returns(new List<Imagen>());
            IInmuebleTipoServiceMock.Setup(x => x.getInmuebleTipos()).Returns(new List<InmuebleTipo>());
            ICiudadServiceMock.Setup(x => x.GetCiudades()).Returns(new List<Ciudades>());

            var inmueble = new InmuebleController(IAuthServiceMock.Object, IInmuebleServiceMock.Object, IImageServiceMock.Object, IInmuebleTipoServiceMock.Object, ICiudadServiceMock.Object, IUsuarioServiceMock.Object, IPublicacionServiceMock.Object, IPlanServiceMock.Object, IValidacionInmuebleMock.Object);

            var result = inmueble.Buscar("Venta") as ViewResult;

            Assert.IsInstanceOf<ViewResult>(result);
            Assert.AreEqual(result.ViewBag.UserLogged, "USUARIO");
            Assert.AreEqual(result.ViewBag.Inmuebles, new List<Inmueble>());
            Assert.AreEqual(result.ViewBag.Imagenes, new List<Imagen>());
            Assert.AreEqual(result.ViewBag.TipoInmueble, new List<InmuebleTipo>());
            Assert.AreEqual(result.ViewBag.ciudad, new List<Ciudades>());



        }
        [Test]
        public void PostBuscarIsOk()
        {
            var IAuthServiceMock = new Mock<IAuthService>();
            var IInmuebleServiceMock = new Mock<IInmuebleService>();
            var IImageServiceMock = new Mock<IImageService>();
            var IInmuebleTipoServiceMock = new Mock<IInmuebleTipoService>();
            var ICiudadServiceMock = new Mock<ICiudadService>();
            var IUsuarioServiceMock = new Mock<IUsuarioService>();
            var IPublicacionServiceMock = new Mock<IPublicacionService>();
            var IPlanServiceMock = new Mock<IPlanService>();
            var IValidacionInmuebleMock = new Mock<IValidacionInmueble>();


            var inmueble = new InmuebleController(IAuthServiceMock.Object, IInmuebleServiceMock.Object, IImageServiceMock.Object, IInmuebleTipoServiceMock.Object, ICiudadServiceMock.Object, IUsuarioServiceMock.Object, IPublicacionServiceMock.Object, IPlanServiceMock.Object, IValidacionInmuebleMock.Object);

             
            var result = inmueble.Buscar(1,1,"Alquiler") as ViewResult;

            Assert.IsInstanceOf<ViewResult>(result);
            Assert.IsNull(result.ViewBag.UserLogged);


        }
        [Test]
        public void PostBuscarWithADMINISTRADORIsOk()
        {
            var IAuthServiceMock = new Mock<IAuthService>();
            var IInmuebleServiceMock = new Mock<IInmuebleService>();
            var IImageServiceMock = new Mock<IImageService>();
            var IInmuebleTipoServiceMock = new Mock<IInmuebleTipoService>();
            var ICiudadServiceMock = new Mock<ICiudadService>();
            var IUsuarioServiceMock = new Mock<IUsuarioService>();
            var IPublicacionServiceMock = new Mock<IPublicacionService>();
            var IPlanServiceMock = new Mock<IPlanService>();
            var IValidacionInmuebleMock = new Mock<IValidacionInmueble>();
            var temp = new Usuario()
            {
                Nombre = "Erick",
                TipoUsuario = "ADMINISTRADOR"
            };
            IAuthServiceMock.Setup(X => X.GetLogedUser()).Returns(temp);
            IInmuebleServiceMock.Setup(X => X.BuscarInmueble(1, 1, "Alquiler")).Returns(new List<Inmueble>());
            IImageServiceMock.Setup(x => x.GetImagenes()).Returns(new List<Imagen>());
            IInmuebleTipoServiceMock.Setup(x => x.getInmuebleTipos()).Returns(new List<InmuebleTipo>());
            ICiudadServiceMock.Setup(x => x.GetCiudades()).Returns(new List<Ciudades>());


            var inmueble = new InmuebleController(IAuthServiceMock.Object, IInmuebleServiceMock.Object, IImageServiceMock.Object, IInmuebleTipoServiceMock.Object, ICiudadServiceMock.Object, IUsuarioServiceMock.Object, IPublicacionServiceMock.Object, IPlanServiceMock.Object, IValidacionInmuebleMock.Object);

            var result = inmueble.Buscar(1, 1, "Alquiler") as ViewResult;

            Assert.IsInstanceOf<ViewResult>(result);
            Assert.AreEqual(result.ViewBag.UserLogged, "ADMINISTRADOR");
            Assert.AreEqual(result.ViewBag.Inmuebles, new List<Inmueble>());
            Assert.AreEqual(result.ViewBag.Imagenes, new List<Imagen>());
            Assert.AreEqual(result.ViewBag.TipoInmueble, new List<InmuebleTipo>());
            Assert.AreEqual(result.ViewBag.ciudad, new List<Ciudades>());


        }
        [Test]
        public void PostBuscarWithAgenteIsOk()
        {
            var IAuthServiceMock = new Mock<IAuthService>();
            var IInmuebleServiceMock = new Mock<IInmuebleService>();
            var IImageServiceMock = new Mock<IImageService>();
            var IInmuebleTipoServiceMock = new Mock<IInmuebleTipoService>();
            var ICiudadServiceMock = new Mock<ICiudadService>();
            var IUsuarioServiceMock = new Mock<IUsuarioService>();
            var IPublicacionServiceMock = new Mock<IPublicacionService>();
            var IPlanServiceMock = new Mock<IPlanService>();
            var IValidacionInmuebleMock = new Mock<IValidacionInmueble>();
            var temp = new Usuario()
            {
                Nombre = "Erick",
                TipoUsuario = "AGENTE"
            };
            IAuthServiceMock.Setup(X => X.GetLogedUser()).Returns(temp);
            IInmuebleServiceMock.Setup(X => X.BuscarInmueble(10, 1, "Alquiler")).Returns(new List<Inmueble>());
            IImageServiceMock.Setup(x => x.GetImagenes()).Returns(new List<Imagen>());
            IInmuebleTipoServiceMock.Setup(x => x.getInmuebleTipos()).Returns(new List<InmuebleTipo>());
            ICiudadServiceMock.Setup(x => x.GetCiudades()).Returns(new List<Ciudades>());


            var inmueble = new InmuebleController(IAuthServiceMock.Object, IInmuebleServiceMock.Object, IImageServiceMock.Object, IInmuebleTipoServiceMock.Object, ICiudadServiceMock.Object, IUsuarioServiceMock.Object, IPublicacionServiceMock.Object, IPlanServiceMock.Object, IValidacionInmuebleMock.Object);

            var result = inmueble.Buscar(10, 1, "Alquiler") as ViewResult;

            Assert.IsInstanceOf<ViewResult>(result);
            Assert.AreEqual(result.ViewBag.UserLogged, "AGENTE");
            Assert.AreEqual(result.ViewBag.Inmuebles, new List<Inmueble>());
            Assert.AreEqual(result.ViewBag.Imagenes, new List<Imagen>());
            Assert.AreEqual(result.ViewBag.TipoInmueble, new List<InmuebleTipo>());
            Assert.AreEqual(result.ViewBag.ciudad, new List<Ciudades>());


        }
        [Test]
        public void PostBuscarWithUserIsOk()
        {
            var IAuthServiceMock = new Mock<IAuthService>();
            var IInmuebleServiceMock = new Mock<IInmuebleService>();
            var IImageServiceMock = new Mock<IImageService>();
            var IInmuebleTipoServiceMock = new Mock<IInmuebleTipoService>();
            var ICiudadServiceMock = new Mock<ICiudadService>();
            var IUsuarioServiceMock = new Mock<IUsuarioService>();
            var IPublicacionServiceMock = new Mock<IPublicacionService>();
            var IPlanServiceMock = new Mock<IPlanService>();
            var IValidacionInmuebleMock = new Mock<IValidacionInmueble>();
            var temp = new Usuario()
            {
                Nombre = "Erick",
                TipoUsuario = "USUARIO"
            };
            IAuthServiceMock.Setup(X => X.GetLogedUser()).Returns(temp);
            IInmuebleServiceMock.Setup(X => X.BuscarInmueble(12, 1, "Venta")).Returns(new List<Inmueble>());
            IImageServiceMock.Setup(x => x.GetImagenes()).Returns(new List<Imagen>());
            IInmuebleTipoServiceMock.Setup(x => x.getInmuebleTipos()).Returns(new List<InmuebleTipo>());
            ICiudadServiceMock.Setup(x => x.GetCiudades()).Returns(new List<Ciudades>());


            var inmueble = new InmuebleController(IAuthServiceMock.Object, IInmuebleServiceMock.Object, IImageServiceMock.Object, IInmuebleTipoServiceMock.Object, ICiudadServiceMock.Object, IUsuarioServiceMock.Object, IPublicacionServiceMock.Object, IPlanServiceMock.Object, IValidacionInmuebleMock.Object);

            var result = inmueble.Buscar(12, 1, "Venta") as ViewResult;

            Assert.IsInstanceOf<ViewResult>(result);
            Assert.AreEqual(result.ViewBag.UserLogged, "USUARIO");
            Assert.AreEqual(result.ViewBag.Inmuebles, new List<Inmueble>());
            Assert.AreEqual(result.ViewBag.Imagenes, new List<Imagen>());
            Assert.AreEqual(result.ViewBag.TipoInmueble, new List<InmuebleTipo>());
            Assert.AreEqual(result.ViewBag.ciudad, new List<Ciudades>());


        }
        [Test]
        public void GetEditarInmuebleIsOk()
        {
            var IAuthServiceMock = new Mock<IAuthService>();
            var IInmuebleServiceMock = new Mock<IInmuebleService>();
            var IImageServiceMock = new Mock<IImageService>();
            var IInmuebleTipoServiceMock = new Mock<IInmuebleTipoService>();
            var ICiudadServiceMock = new Mock<ICiudadService>();
            var IUsuarioServiceMock = new Mock<IUsuarioService>();

            var IPublicacionServiceMock = new Mock<IPublicacionService>();

            var IPlanServiceMock = new Mock<IPlanService>();

            var IValidacionInmuebleMock = new Mock<IValidacionInmueble>();
            IInmuebleServiceMock.Setup(x => x.GetInmuebleById(1)).Returns(new Inmueble());

            var inmueble = new InmuebleController(IAuthServiceMock.Object, IInmuebleServiceMock.Object, IImageServiceMock.Object, IInmuebleTipoServiceMock.Object, ICiudadServiceMock.Object, IUsuarioServiceMock.Object, IPublicacionServiceMock.Object, IPlanServiceMock.Object, IValidacionInmuebleMock.Object);

            //var inmuebles = IInmuebleServiceMock.Setup(x=>x.GetInmubles()).Returns(new List<Inmueble>());
            var result = inmueble.Inmueble(1) as ViewResult;

            Assert.IsInstanceOf<ViewResult>(result);
            Assert.IsNull(result.ViewBag.UserLogged);


        }
        [Test]
        public void GetEditarInmueblewithAdminIsOk()
        {
            var IAuthServiceMock = new Mock<IAuthService>();
            var IInmuebleServiceMock = new Mock<IInmuebleService>();
            var IImageServiceMock = new Mock<IImageService>();
            var IInmuebleTipoServiceMock = new Mock<IInmuebleTipoService>();
            var ICiudadServiceMock = new Mock<ICiudadService>();
            var IUsuarioServiceMock = new Mock<IUsuarioService>();
            var IPublicacionServiceMock = new Mock<IPublicacionService>();
            var IPlanServiceMock = new Mock<IPlanService>();
            var IValidacionInmuebleMock = new Mock<IValidacionInmueble>();

            var temp = new Usuario()
            {
                UsuarioId=1,
                Nombre = "Erick",
                TipoUsuario = "ADMINISTRADOR"
            };
            var tempINM = new Inmueble()
            {
                InmuebleId = 1,
                NombreInm = "NUEVO",
                
            };
               IAuthServiceMock.Setup(X => X.GetLogedUser()).Returns(temp);
            IInmuebleServiceMock.Setup(X => X.GetInmuebleById(1)).Returns(tempINM);
            IImageServiceMock.Setup(x => x.GetAllImagenesByInmuebleID(1)).Returns(new List<Imagen>());
            IInmuebleTipoServiceMock.Setup(x => x.getInmuebleTipos()).Returns(new List<InmuebleTipo>());
            ICiudadServiceMock.Setup(x => x.GetCiudades()).Returns(new List<Ciudades>());
 
            var inmueble = new InmuebleController(IAuthServiceMock.Object, IInmuebleServiceMock.Object, IImageServiceMock.Object, IInmuebleTipoServiceMock.Object, ICiudadServiceMock.Object, IUsuarioServiceMock.Object, IPublicacionServiceMock.Object, IPlanServiceMock.Object, IValidacionInmuebleMock.Object);

             var result = inmueble.Inmueble(1) as ViewResult;

            Assert.IsInstanceOf<ViewResult>(result);
            Assert.AreEqual(result.ViewBag.UserLogged, "ADMINISTRADOR");
            Assert.AreEqual(result.ViewBag.Inmueble, tempINM);
            Assert.AreEqual(result.ViewBag.Ciudades, new List<Ciudades>());
            Assert.AreEqual(result.ViewBag.InmuebleTipo, new List<InmuebleTipo>());
            Assert.AreEqual(result.ViewBag.Imagen, new List<Imagen>());

        }
        [Test]
        public void GetEditarInmueblewithAgenteIsOk()
        {
            var IAuthServiceMock = new Mock<IAuthService>();
            var IInmuebleServiceMock = new Mock<IInmuebleService>();
            var IImageServiceMock = new Mock<IImageService>();
            var IInmuebleTipoServiceMock = new Mock<IInmuebleTipoService>();
            var ICiudadServiceMock = new Mock<ICiudadService>();
            var IUsuarioServiceMock = new Mock<IUsuarioService>();
            var IPublicacionServiceMock = new Mock<IPublicacionService>();
            var IPlanServiceMock = new Mock<IPlanService>();
            var IValidacionInmuebleMock = new Mock<IValidacionInmueble>();

            var temp = new Usuario()
            {
                UsuarioId = 1,
                Nombre = "Erick",
                TipoUsuario = "AGENTE"
            };
            var tempINM = new Inmueble()
            {
                InmuebleId = 1,
                NombreInm = "NUEVO",

            };
            IAuthServiceMock.Setup(X => X.GetLogedUser()).Returns(temp);
            IInmuebleServiceMock.Setup(X => X.GetInmuebleById(1)).Returns(tempINM);
            IImageServiceMock.Setup(x => x.GetAllImagenesByInmuebleID(1)).Returns(new List<Imagen>());
            IInmuebleTipoServiceMock.Setup(x => x.getInmuebleTipos()).Returns(new List<InmuebleTipo>());
            ICiudadServiceMock.Setup(x => x.GetCiudades()).Returns(new List<Ciudades>());

            var inmueble = new InmuebleController(IAuthServiceMock.Object, IInmuebleServiceMock.Object, IImageServiceMock.Object, IInmuebleTipoServiceMock.Object, ICiudadServiceMock.Object, IUsuarioServiceMock.Object, IPublicacionServiceMock.Object, IPlanServiceMock.Object, IValidacionInmuebleMock.Object);

            var result = inmueble.Inmueble(1) as ViewResult;

            Assert.IsInstanceOf<ViewResult>(result);
            Assert.AreEqual(result.ViewBag.UserLogged, "AGENTE");
            Assert.AreEqual(result.ViewBag.Inmueble, tempINM);
            Assert.AreEqual(result.ViewBag.Ciudades, new List<Ciudades>());
            Assert.AreEqual(result.ViewBag.InmuebleTipo, new List<InmuebleTipo>());
            Assert.AreEqual(result.ViewBag.Imagen, new List<Imagen>());

        }
        [Test]
        public void GetEditarInmueblewithUSUARIOIsOk()
        {
            var IAuthServiceMock = new Mock<IAuthService>();
            var IInmuebleServiceMock = new Mock<IInmuebleService>();
            var IImageServiceMock = new Mock<IImageService>();
            var IInmuebleTipoServiceMock = new Mock<IInmuebleTipoService>();
            var ICiudadServiceMock = new Mock<ICiudadService>();
            var IUsuarioServiceMock = new Mock<IUsuarioService>();
            var IPublicacionServiceMock = new Mock<IPublicacionService>();
            var IPlanServiceMock = new Mock<IPlanService>();
            var IValidacionInmuebleMock = new Mock<IValidacionInmueble>();

            var temp = new Usuario()
            {
                UsuarioId = 1,
                Nombre = "Erick",
                TipoUsuario = "USUARIO"
            };
            var tempINM = new Inmueble()
            {
                InmuebleId = 1,
                NombreInm = "NUEVO",

            };
            IAuthServiceMock.Setup(X => X.GetLogedUser()).Returns(temp);
            IInmuebleServiceMock.Setup(X => X.GetInmuebleById(1)).Returns(tempINM);
            IImageServiceMock.Setup(x => x.GetAllImagenesByInmuebleID(1)).Returns(new List<Imagen>());
            IInmuebleTipoServiceMock.Setup(x => x.getInmuebleTipos()).Returns(new List<InmuebleTipo>());
            ICiudadServiceMock.Setup(x => x.GetCiudades()).Returns(new List<Ciudades>());

            var inmueble = new InmuebleController(IAuthServiceMock.Object, IInmuebleServiceMock.Object, IImageServiceMock.Object, IInmuebleTipoServiceMock.Object, ICiudadServiceMock.Object, IUsuarioServiceMock.Object, IPublicacionServiceMock.Object, IPlanServiceMock.Object, IValidacionInmuebleMock.Object);

            var result = inmueble.Inmueble(1) as ViewResult;

            Assert.IsInstanceOf<ViewResult>(result);
            Assert.AreEqual(result.ViewBag.UserLogged, "USUARIO");
            Assert.AreEqual(result.ViewBag.Inmueble, tempINM);
            Assert.AreEqual(result.ViewBag.Ciudades, new List<Ciudades>());
            Assert.AreEqual(result.ViewBag.InmuebleTipo, new List<InmuebleTipo>());
            Assert.AreEqual(result.ViewBag.Imagen, new List<Imagen>());

        }
        [Test]
        public void PostEditarInmuebleIsOk() {
            var IAuthServiceMock = new Mock<IAuthService>();
            var IInmuebleServiceMock = new Mock<IInmuebleService>();
            var IImageServiceMock = new Mock<IImageService>();
            var IInmuebleTipoServiceMock = new Mock<IInmuebleTipoService>();
            var ICiudadServiceMock = new Mock<ICiudadService>();
            var IUsuarioServiceMock = new Mock<IUsuarioService>();
            var IPublicacionServiceMock = new Mock<IPublicacionService>();
            var IPlanServiceMock = new Mock<IPlanService>();
            var IValidacionInmuebleMock = new Mock<IValidacionInmueble>();

            var temp = new Usuario()
            {
                UsuarioId = 1,
                Nombre = "Erick",
                TipoUsuario = "USUARIO"
            };
            var tempINM = new Inmueble()
            {
                InmuebleId = 1,
                NombreInm = "NUEVO",

            };
            IAuthServiceMock.Setup(X => X.GetLogedUser()).Returns(temp);
            IInmuebleServiceMock.Setup(X => X.GetInmuebleById(1)).Returns(tempINM);
 
            var inmueble = new InmuebleController(IAuthServiceMock.Object, IInmuebleServiceMock.Object, IImageServiceMock.Object, IInmuebleTipoServiceMock.Object, ICiudadServiceMock.Object, IUsuarioServiceMock.Object, IPublicacionServiceMock.Object, IPlanServiceMock.Object, IValidacionInmuebleMock.Object);

            var result = inmueble.Inmueble(tempINM,1,10,new List<HttpPostedFileBase>()) as RedirectToRouteResult;
       
            Assert.IsInstanceOf<RedirectToRouteResult>(result);
           
        }
        [Test]
        public void PostEditarInmuebleWithUserIsNullIsOk()
        {
            var IAuthServiceMock = new Mock<IAuthService>();
            var IInmuebleServiceMock = new Mock<IInmuebleService>();
            var IImageServiceMock = new Mock<IImageService>();
            var IInmuebleTipoServiceMock = new Mock<IInmuebleTipoService>();
            var ICiudadServiceMock = new Mock<ICiudadService>();
            var IUsuarioServiceMock = new Mock<IUsuarioService>();
            var IPublicacionServiceMock = new Mock<IPublicacionService>();
            var IPlanServiceMock = new Mock<IPlanService>();
            var IValidacionInmuebleMock = new Mock<IValidacionInmueble>();


            var tempINM = new Inmueble()
            {
                InmuebleId = 1,
                NombreInm = "NUEVO",
            };
     
            IInmuebleServiceMock.Setup(X => X.GetInmuebleById(1)).Returns(tempINM);

            var inmueble = new InmuebleController(IAuthServiceMock.Object, IInmuebleServiceMock.Object, IImageServiceMock.Object, IInmuebleTipoServiceMock.Object, ICiudadServiceMock.Object, IUsuarioServiceMock.Object, IPublicacionServiceMock.Object, IPlanServiceMock.Object, IValidacionInmuebleMock.Object);

            var result = inmueble.Inmueble(tempINM, 1, 10, new List<HttpPostedFileBase>()) as RedirectToRouteResult;

            Assert.IsInstanceOf<RedirectToRouteResult>(result);
            

        }
        [Test]
        public void PostEditarInmuebleWithErrorIsOk()
        {
            var IAuthServiceMock = new Mock<IAuthService>();
            var IInmuebleServiceMock = new Mock<IInmuebleService>();
            var IImageServiceMock = new Mock<IImageService>();
            var IInmuebleTipoServiceMock = new Mock<IInmuebleTipoService>();
            var ICiudadServiceMock = new Mock<ICiudadService>();
            var IUsuarioServiceMock = new Mock<IUsuarioService>();
            var IPublicacionServiceMock = new Mock<IPublicacionService>();
            var IPlanServiceMock = new Mock<IPlanService>();
            var IValidacionInmuebleMock = new Mock<IValidacionInmueble>();

            var temp = new Usuario()
            {
                UsuarioId = 1,
                Nombre = "Erick",
                TipoUsuario = "USUARIO"
            };
            var tempINM = new Inmueble()
            {
                InmuebleId = 1,
                NombreInm = "NUEVO",
            };
            
      
            IAuthServiceMock.Setup(X => X.GetLogedUser()).Returns(temp);
            IInmuebleServiceMock.Setup(X => X.GetInmuebleById(1)).Returns(tempINM);

            //IValidacionInmuebleMock.Setup(x => x.validarInmueble(tempINM, modelState)).Verifiable(modelstate.);

            var inmueble = new InmuebleController(IAuthServiceMock.Object, IInmuebleServiceMock.Object, IImageServiceMock.Object, IInmuebleTipoServiceMock.Object, ICiudadServiceMock.Object, IUsuarioServiceMock.Object, IPublicacionServiceMock.Object, IPlanServiceMock.Object, IValidacionInmuebleMock.Object);
            inmueble.ModelState.AddModelError("Error", "No pasa");
            var result = inmueble.Inmueble(tempINM, 1, 10, new List<HttpPostedFileBase>()) as ViewResult;

            Assert.IsInstanceOf<ViewResult>(result);
            Assert.AreEqual(result.ViewBag.Inmueble, tempINM);
            Assert.AreEqual(result.ViewBag.Ciudades, new List<Ciudades>());
            Assert.AreEqual(result.ViewBag.InmuebleTipo, new List<InmuebleTipo>());
            Assert.AreEqual(result.ViewBag.Imagen, new List<Imagen>());
            Assert.AreEqual(result.ViewBag.UserLogged, "USUARIO");


        }
        [Test]
        public void DelImgIsOk()
        {
            var IAuthServiceMock = new Mock<IAuthService>();
            var IInmuebleServiceMock = new Mock<IInmuebleService>();
            var IImageServiceMock = new Mock<IImageService>();
            var IInmuebleTipoServiceMock = new Mock<IInmuebleTipoService>();
            var ICiudadServiceMock = new Mock<ICiudadService>();
            var IUsuarioServiceMock = new Mock<IUsuarioService>();

            var IPublicacionServiceMock = new Mock<IPublicacionService>();

            var IPlanServiceMock = new Mock<IPlanService>();

            var IValidacionInmuebleMock = new Mock<IValidacionInmueble>();
       

            var inmueble = new InmuebleController(IAuthServiceMock.Object, IInmuebleServiceMock.Object, IImageServiceMock.Object, IInmuebleTipoServiceMock.Object, ICiudadServiceMock.Object, IUsuarioServiceMock.Object, IPublicacionServiceMock.Object, IPlanServiceMock.Object, IValidacionInmuebleMock.Object);

            //var inmuebles = IInmuebleServiceMock.Setup(x=>x.GetInmubles()).Returns(new List<Inmueble>());
            var result = inmueble.DelImg(1) ;

            Assert.IsInstanceOf<JsonResult>(result);
  


        }
        [Test]
        public void InmLayoutIsOk()
        {
            var IAuthServiceMock = new Mock<IAuthService>();
            var IInmuebleServiceMock = new Mock<IInmuebleService>();
            var IImageServiceMock = new Mock<IImageService>();
            var IInmuebleTipoServiceMock = new Mock<IInmuebleTipoService>();
            var ICiudadServiceMock = new Mock<ICiudadService>();
            var IUsuarioServiceMock = new Mock<IUsuarioService>();

            var IPublicacionServiceMock = new Mock<IPublicacionService>();

            var IPlanServiceMock = new Mock<IPlanService>();

            var IValidacionInmuebleMock = new Mock<IValidacionInmueble>();


            var inmueble = new InmuebleController(IAuthServiceMock.Object, IInmuebleServiceMock.Object, IImageServiceMock.Object, IInmuebleTipoServiceMock.Object, ICiudadServiceMock.Object, IUsuarioServiceMock.Object, IPublicacionServiceMock.Object, IPlanServiceMock.Object, IValidacionInmuebleMock.Object);

            var result = inmueble.InmLayout();

            Assert.IsInstanceOf<JsonResult>(result);



        }
    }
}
