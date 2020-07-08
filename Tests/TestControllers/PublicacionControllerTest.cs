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
    class PublicacionControllerTest
    {
        [Test]
        public void GetIndexIsOk()
        {
    
            var IAuthServiceMock = new Mock<IAuthService>();
            var IPlanServiceMock = new Mock<IPlanService>();
            var IInmuebleTipoServiceMock = new Mock<IInmuebleTipoService>();
            var ICiudadServiceMock = new Mock<ICiudadService>();
            var ICloudinaryServiceMock = new Mock<ICloudinaryService>();
            var IInmuebleServiceMock = new Mock<IInmuebleService>();
            var IImageServiceMock = new Mock<IImageService>();

            var IPublicacionServiceMock = new Mock<IPublicacionService>();
            var IValidacionInmuebleMock = new Mock<IValidacionInmueble>();
          
          
            var home = new PublicacionController(IAuthServiceMock.Object, IPlanServiceMock.Object, IInmuebleTipoServiceMock.Object, ICiudadServiceMock.Object, ICloudinaryServiceMock.Object, IInmuebleServiceMock.Object, IImageServiceMock.Object, IPublicacionServiceMock.Object, IValidacionInmuebleMock.Object);

          
            var result = home.Index() as ViewResult;

            Assert.IsInstanceOf<ViewResult>(result);
      

        }
        [Test]
        public void GetAddPublicacionWithUserIsOk()
        {

            var IAuthServiceMock = new Mock<IAuthService>();
            var IPlanServiceMock = new Mock<IPlanService>();
            var IInmuebleTipoServiceMock = new Mock<IInmuebleTipoService>();
            var ICiudadServiceMock = new Mock<ICiudadService>();
            var ICloudinaryServiceMock = new Mock<ICloudinaryService>();
            var IInmuebleServiceMock = new Mock<IInmuebleService>();
            var IImageServiceMock = new Mock<IImageService>();
            var IPublicacionServiceMock = new Mock<IPublicacionService>();
            var IValidacionInmuebleMock = new Mock<IValidacionInmueble>();
            var temp = new Usuario()
            {
                Nombre = "Erick",
                TipoUsuario = "USUARIO"
            };
            IAuthServiceMock.Setup(x => x.GetLogedUser()).Returns(temp);
            IPlanServiceMock.Setup(x => x.getPlans()).Returns(new List<Plan>());
            IInmuebleTipoServiceMock.Setup(x => x.getInmuebleTipos()).Returns(new List<InmuebleTipo>());
            ICiudadServiceMock.Setup(x => x.GetCiudades()).Returns(new List<Ciudades>());
            var publicacion = new PublicacionController(IAuthServiceMock.Object, IPlanServiceMock.Object, IInmuebleTipoServiceMock.Object, ICiudadServiceMock.Object, ICloudinaryServiceMock.Object, IInmuebleServiceMock.Object, IImageServiceMock.Object, IPublicacionServiceMock.Object, IValidacionInmuebleMock.Object);
            

            var result = publicacion.AddPublicacion() as ViewResult;

            Assert.IsInstanceOf<ViewResult>(result);
            Assert.AreEqual(result.ViewBag.UserLogged, "USUARIO");
            Assert.AreEqual(result.ViewBag.Plans, new List<Plan>());
            Assert.AreEqual(result.ViewBag.InmuebleTipo, new List<InmuebleTipo>());
            Assert.AreEqual(result.ViewBag.Ciudades, new List<Ciudades>());


        }
        [Test]
        public void GetAddPublicacionWithUserIsNullIsOk()
        {

            var IAuthServiceMock = new Mock<IAuthService>();
            var IPlanServiceMock = new Mock<IPlanService>();
            var IInmuebleTipoServiceMock = new Mock<IInmuebleTipoService>();
            var ICiudadServiceMock = new Mock<ICiudadService>();
            var ICloudinaryServiceMock = new Mock<ICloudinaryService>();
            var IInmuebleServiceMock = new Mock<IInmuebleService>();
            var IImageServiceMock = new Mock<IImageService>();

            var IPublicacionServiceMock = new Mock<IPublicacionService>();
            var IValidacionInmuebleMock = new Mock<IValidacionInmueble>();


            var publicacion = new PublicacionController(IAuthServiceMock.Object, IPlanServiceMock.Object, IInmuebleTipoServiceMock.Object, ICiudadServiceMock.Object, ICloudinaryServiceMock.Object, IInmuebleServiceMock.Object, IImageServiceMock.Object, IPublicacionServiceMock.Object, IValidacionInmuebleMock.Object);


            var result = publicacion.AddPublicacion() as RedirectToRouteResult;

            Assert.IsInstanceOf<RedirectToRouteResult>(result);
 

        }
        [Test]
        public void PostAddPublicacionWithUserIsOk() {
     
            var IAuthServiceMock = new Mock<IAuthService>();
            var IPlanServiceMock = new Mock<IPlanService>();
            var IInmuebleTipoServiceMock = new Mock<IInmuebleTipoService>();
            var ICiudadServiceMock = new Mock<ICiudadService>();
            var ICloudinaryServiceMock = new Mock<ICloudinaryService>();
            var IInmuebleServiceMock = new Mock<IInmuebleService>();
            var IImageServiceMock = new Mock<IImageService>();
            var IPublicacionServiceMock = new Mock<IPublicacionService>();
            var IValidacionInmuebleMock = new Mock<IValidacionInmueble>();
            var temp = new Usuario()
            {
                Nombre = "Erick",
                TipoUsuario = "USUARIO"
            };   
 
            IAuthServiceMock.Setup(x => x.GetLogedUser()).Returns(temp);
            IPlanServiceMock.Setup(x => x.getPlans()).Returns(new List<Plan>());
            IInmuebleTipoServiceMock.Setup(x => x.getInmuebleTipos()).Returns(new List<InmuebleTipo>());
            ICiudadServiceMock.Setup(x => x.GetCiudades()).Returns(new List<Ciudades>());
            var publicacion = new PublicacionController(IAuthServiceMock.Object, IPlanServiceMock.Object, IInmuebleTipoServiceMock.Object, ICiudadServiceMock.Object, ICloudinaryServiceMock.Object, IInmuebleServiceMock.Object, IImageServiceMock.Object, IPublicacionServiceMock.Object, IValidacionInmuebleMock.Object);


            var result = publicacion.AddPublicacion(new Inmueble(),1,5, new List<HttpPostedFileBase>() ) as ViewResult;

            Assert.IsInstanceOf<ViewResult>(result);
        

        }
        [Test]
        public void PostAddPublicacionWithUserIsNull()
        {

            var IAuthServiceMock = new Mock<IAuthService>();
            var IPlanServiceMock = new Mock<IPlanService>();
            var IInmuebleTipoServiceMock = new Mock<IInmuebleTipoService>();
            var ICiudadServiceMock = new Mock<ICiudadService>();
            var ICloudinaryServiceMock = new Mock<ICloudinaryService>();
            var IInmuebleServiceMock = new Mock<IInmuebleService>();
            var IImageServiceMock = new Mock<IImageService>();
            var IPublicacionServiceMock = new Mock<IPublicacionService>();
            var IValidacionInmuebleMock = new Mock<IValidacionInmueble>();
             
            
            var publicacion = new PublicacionController(IAuthServiceMock.Object, IPlanServiceMock.Object, IInmuebleTipoServiceMock.Object, ICiudadServiceMock.Object, ICloudinaryServiceMock.Object, IInmuebleServiceMock.Object, IImageServiceMock.Object, IPublicacionServiceMock.Object, IValidacionInmuebleMock.Object);


            var result = publicacion.AddPublicacion(new Inmueble(), 2, 15, new List<HttpPostedFileBase>()) as RedirectToRouteResult;

            Assert.IsInstanceOf<RedirectToRouteResult>(result);


        }
        [Test]
        public void PostAddPublicacionWithModelStateErrorIsOk()
        {

            var IAuthServiceMock = new Mock<IAuthService>();
            var IPlanServiceMock = new Mock<IPlanService>();
            var IInmuebleTipoServiceMock = new Mock<IInmuebleTipoService>();
            var ICiudadServiceMock = new Mock<ICiudadService>();
            var ICloudinaryServiceMock = new Mock<ICloudinaryService>();
            var IInmuebleServiceMock = new Mock<IInmuebleService>();
            var IImageServiceMock = new Mock<IImageService>();
            var IPublicacionServiceMock = new Mock<IPublicacionService>();
            var IValidacionInmuebleMock = new Mock<IValidacionInmueble>();
            var temp = new Usuario()
            {
                Nombre = "Erick",
                TipoUsuario = "USUARIO"
            };

            IAuthServiceMock.Setup(x => x.GetLogedUser()).Returns(temp);
            IPlanServiceMock.Setup(x => x.getPlans()).Returns(new List<Plan>());
            IInmuebleTipoServiceMock.Setup(x => x.getInmuebleTipos()).Returns(new List<InmuebleTipo>());
            ICiudadServiceMock.Setup(x => x.GetCiudades()).Returns(new List<Ciudades>());
            var publicacion = new PublicacionController(IAuthServiceMock.Object, IPlanServiceMock.Object, IInmuebleTipoServiceMock.Object, ICiudadServiceMock.Object, ICloudinaryServiceMock.Object, IInmuebleServiceMock.Object, IImageServiceMock.Object, IPublicacionServiceMock.Object, IValidacionInmuebleMock.Object);

            publicacion.ModelState.AddModelError("Error","No Carga");
            var result = publicacion.AddPublicacion(new Inmueble(), 1, 5, new List<HttpPostedFileBase>()) as ViewResult;
      
            Assert.IsInstanceOf<ViewResult>(result);
            Assert.AreEqual(result.ViewBag.Plans, new List<Plan>());
            Assert.AreEqual(result.ViewBag.InmuebleTipo, new List<InmuebleTipo>());
            Assert.AreEqual(result.ViewBag.Ciudades, new List<Ciudades>());
            Assert.AreEqual(result.ViewBag.UserLogged, "USUARIO");
        }
        [Test]
        public void GetInmuebleByIDWithUserLoggedNullIsOk()
        {

            var IAuthServiceMock = new Mock<IAuthService>();
            var IPlanServiceMock = new Mock<IPlanService>();
            var IInmuebleTipoServiceMock = new Mock<IInmuebleTipoService>();
            var ICiudadServiceMock = new Mock<ICiudadService>();
            var ICloudinaryServiceMock = new Mock<ICloudinaryService>();
            var IInmuebleServiceMock = new Mock<IInmuebleService>();
            var IImageServiceMock = new Mock<IImageService>();

            var IPublicacionServiceMock = new Mock<IPublicacionService>();
            var IValidacionInmuebleMock = new Mock<IValidacionInmueble>();
            var tempInmueble = new Inmueble() { };
            IInmuebleServiceMock.Setup(x => x.GetInmuebleById(1)).Returns(new Inmueble());
            IPlanServiceMock.Setup(x => x.getPlans()).Returns(new List<Plan>());
            IInmuebleTipoServiceMock.Setup(x => x.getInmuebleTipos()).Returns(new List<InmuebleTipo>());
            ICiudadServiceMock.Setup(x => x.GetCiudades()).Returns(new List<Ciudades>());
            IImageServiceMock.Setup(x => x.GetAllImagenesByInmuebleID(1)).Returns(new List<Imagen>());
            IInmuebleServiceMock.Setup(x => x.GetInmuebleById(1)).Returns(tempInmueble);
            var publicacion = new PublicacionController(IAuthServiceMock.Object, IPlanServiceMock.Object, IInmuebleTipoServiceMock.Object, ICiudadServiceMock.Object, ICloudinaryServiceMock.Object, IInmuebleServiceMock.Object, IImageServiceMock.Object, IPublicacionServiceMock.Object, IValidacionInmuebleMock.Object);


            var result = publicacion.GetInmuebleByID(1) as ViewResult;

            Assert.IsInstanceOf<ViewResult>(result);

            Assert.IsNull(result.ViewBag.UserLogged);
            Assert.AreEqual(result.ViewBag.Inmueble, tempInmueble);
            Assert.AreEqual(result.ViewBag.InmuebleTipo, new List<InmuebleTipo>());
            Assert.AreEqual(result.ViewBag.Ciudades, new List<Ciudades>());
            Assert.AreEqual(result.ViewBag.Imagenes, new List<Imagen>());
            Assert.AreEqual(result.ViewBag.AllImgInmuebles, new List<Imagen>());
            Assert.AreEqual(result.ViewBag.Inmuebles, new List<Inmueble>());

        }
        [Test]
        public void GetInmuebleByIDWithUserIsOk()
        {

            var IAuthServiceMock = new Mock<IAuthService>();
            var IPlanServiceMock = new Mock<IPlanService>();
            var IInmuebleTipoServiceMock = new Mock<IInmuebleTipoService>();
            var ICiudadServiceMock = new Mock<ICiudadService>();
            var ICloudinaryServiceMock = new Mock<ICloudinaryService>();
            var IInmuebleServiceMock = new Mock<IInmuebleService>();
            var IImageServiceMock = new Mock<IImageService>();

            var IPublicacionServiceMock = new Mock<IPublicacionService>();
            var IValidacionInmuebleMock = new Mock<IValidacionInmueble>();
            var temp = new Usuario()
            {
                Nombre = "Erick",
                TipoUsuario = "USUARIO"
            };
            var tempInmueble = new Inmueble() { };
            IAuthServiceMock.Setup(x => x.GetLogedUser()).Returns(temp);
            IPlanServiceMock.Setup(x => x.getPlans()).Returns(new List<Plan>());
            IInmuebleTipoServiceMock.Setup(x => x.getInmuebleTipos()).Returns(new List<InmuebleTipo>());
            ICiudadServiceMock.Setup(x => x.GetCiudades()).Returns(new List<Ciudades>());
            IImageServiceMock.Setup(x => x.GetAllImagenesByInmuebleID(1)).Returns(new List<Imagen>());
            IInmuebleServiceMock.Setup(x => x.GetInmuebleById(1)).Returns(tempInmueble);

            var publicacion = new PublicacionController(IAuthServiceMock.Object, IPlanServiceMock.Object, IInmuebleTipoServiceMock.Object, ICiudadServiceMock.Object, ICloudinaryServiceMock.Object, IInmuebleServiceMock.Object, IImageServiceMock.Object, IPublicacionServiceMock.Object, IValidacionInmuebleMock.Object);

   
            var result = publicacion.GetInmuebleByID(1) as ViewResult;

            Assert.IsInstanceOf<ViewResult>(result);
            Assert.AreEqual(result.ViewBag.UserLogged, "USUARIO");
            Assert.AreEqual(result.ViewBag.Inmueble, tempInmueble);
            Assert.AreEqual(result.ViewBag.InmuebleTipo, new List<InmuebleTipo>());
            Assert.AreEqual(result.ViewBag.Ciudades, new List<Ciudades>());
            Assert.AreEqual(result.ViewBag.Imagenes, new List<Imagen>());
            Assert.AreEqual(result.ViewBag.AllImgInmuebles, new List<Imagen>());
            Assert.AreEqual(result.ViewBag.Inmuebles, new List<Inmueble>());

        }
        [Test]
        public void DireccionesIsOk()
        {

            var IAuthServiceMock = new Mock<IAuthService>();
            var IPlanServiceMock = new Mock<IPlanService>();
            var IInmuebleTipoServiceMock = new Mock<IInmuebleTipoService>();
            var ICiudadServiceMock = new Mock<ICiudadService>();
            var ICloudinaryServiceMock = new Mock<ICloudinaryService>();
            var IInmuebleServiceMock = new Mock<IInmuebleService>();
            var IImageServiceMock = new Mock<IImageService>();

            var IPublicacionServiceMock = new Mock<IPublicacionService>();
            var IValidacionInmuebleMock = new Mock<IValidacionInmueble>();


            var home = new PublicacionController(IAuthServiceMock.Object, IPlanServiceMock.Object, IInmuebleTipoServiceMock.Object, ICiudadServiceMock.Object, ICloudinaryServiceMock.Object, IInmuebleServiceMock.Object, IImageServiceMock.Object, IPublicacionServiceMock.Object, IValidacionInmuebleMock.Object);


            var result = home.Direcciones() as ViewResult;

            Assert.IsInstanceOf<ViewResult>(result);


        }
    }
}
