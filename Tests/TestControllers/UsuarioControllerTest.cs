using HousesPeru.Controllers;
using HousesPeru.Models;
using HousesPeru.services;
using HousesPeru.validaciones;
using HousesPeru.ViewModels;
using Moq;
using NUnit.Framework;
using System;
 
using System.Web;
using System.Web.Mvc;

namespace Tests.TestControllers
{
    [TestFixture]
    class UsuarioControllerTest
    {
 
        [Test]
        public void GetRegistroAgenteWithUserLoggedIsNullIsOk() {
            var IUsuarioServiceMock = new Mock<IUsuarioService>();
            var IValidacionUsuarioMock = new Mock<IValidacionUsuario>();
            var IAuthServiceMock = new Mock<IAuthService>(); 
            var IInmuebleServiceMock = new Mock<IInmuebleService>(); 
            var IImageServiceMock = new Mock<IImageService>();
            var ICloudinaryServiceMock = new Mock<ICloudinaryService>();
             
            var home = new UsuarioController(IUsuarioServiceMock.Object, IValidacionUsuarioMock.Object, IAuthServiceMock.Object, IInmuebleServiceMock.Object, IImageServiceMock.Object, ICloudinaryServiceMock.Object);
            var result=home.RegistroAgente();

            Assert.IsInstanceOf<RedirectToRouteResult>(result);
 
        }
        [Test]
        public void GetRegistroAgenteWithUserErrorIsOk()
        {
            var IUsuarioServiceMock = new Mock<IUsuarioService>();
            var IValidacionUsuarioMock = new Mock<IValidacionUsuario>();
            var IAuthServiceMock = new Mock<IAuthService>();
            var IInmuebleServiceMock = new Mock<IInmuebleService>();
            var IImageServiceMock = new Mock<IImageService>();
            var ICloudinaryServiceMock = new Mock<ICloudinaryService>();
            var Temp = new Usuario() { UsuarioId=1, Nombre="prueba",TipoUsuario="USUARIO"};
            IAuthServiceMock.Setup(x => x.GetLogedUser()).Returns(Temp);
            var usuario = new UsuarioController(IUsuarioServiceMock.Object, IValidacionUsuarioMock.Object, IAuthServiceMock.Object, IInmuebleServiceMock.Object, IImageServiceMock.Object, ICloudinaryServiceMock.Object);
            var result = usuario.RegistroAgente() as RedirectToRouteResult;

            Assert.IsInstanceOf<RedirectToRouteResult>(result);
            
        }
        [Test]
        public void GetRegistroAgenteWithAdminIsOk()
        {
            var IUsuarioServiceMock = new Mock<IUsuarioService>();
            var IValidacionUsuarioMock = new Mock<IValidacionUsuario>();
            var IAuthServiceMock = new Mock<IAuthService>();
            var IInmuebleServiceMock = new Mock<IInmuebleService>();
            var IImageServiceMock = new Mock<IImageService>();
            var ICloudinaryServiceMock = new Mock<ICloudinaryService>();
            var Temp = new Usuario() { UsuarioId = 1, Nombre = "prueba", TipoUsuario = "ADMINISTRADOR" };
            IAuthServiceMock.Setup(x => x.GetLogedUser()).Returns(Temp);
            var usuario = new UsuarioController(IUsuarioServiceMock.Object, IValidacionUsuarioMock.Object, IAuthServiceMock.Object, IInmuebleServiceMock.Object, IImageServiceMock.Object, ICloudinaryServiceMock.Object);
            var result = usuario.RegistroAgente() as ViewResult;

            Assert.IsInstanceOf<ViewResult>(result);
            Assert.AreEqual(result.ViewBag.UserLogged, "ADMINISTRADOR");

        }
        [Test]
        public void PostRegistroAgenteUserLoggedIsOk()
        {
            var IUsuarioServiceMock = new Mock<IUsuarioService>();
            var IValidacionUsuarioMock = new Mock<IValidacionUsuario>();
            var IAuthServiceMock = new Mock<IAuthService>();
            var IInmuebleServiceMock = new Mock<IInmuebleService>();
            var IImageServiceMock = new Mock<IImageService>();
            var ICloudinaryServiceMock = new Mock<ICloudinaryService>();

            IAuthServiceMock.Setup(x => x.GetLogedUser()).Returns(new Usuario());
            var usuario = new UsuarioController(IUsuarioServiceMock.Object, IValidacionUsuarioMock.Object, IAuthServiceMock.Object, IInmuebleServiceMock.Object, IImageServiceMock.Object, ICloudinaryServiceMock.Object);
            var result = usuario.RegistroAgente(new UsuarioViewModel());

            Assert.IsInstanceOf<RedirectToRouteResult>(result);

        }
        [Test]
        public void PostRegistroAgenteAdminLoggedIsOk()
        {
            var IUsuarioServiceMock = new Mock<IUsuarioService>();
            var IValidacionUsuarioMock = new Mock<IValidacionUsuario>();
            var IAuthServiceMock = new Mock<IAuthService>();
            var IInmuebleServiceMock = new Mock<IInmuebleService>();
            var IImageServiceMock = new Mock<IImageService>();
            var ICloudinaryServiceMock = new Mock<ICloudinaryService>();
            var temp = new Usuario() {UsuarioId=1,Nombre="prueba" ,TipoUsuario="ADMINISTRACION"};
            IAuthServiceMock.Setup(x => x.GetLogedUser()).Returns(temp);
            var usuario = new UsuarioController(IUsuarioServiceMock.Object, IValidacionUsuarioMock.Object, IAuthServiceMock.Object, IInmuebleServiceMock.Object, IImageServiceMock.Object, ICloudinaryServiceMock.Object);
            var result = usuario.RegistroAgente(new UsuarioViewModel()) as RedirectToRouteResult;

            Assert.IsInstanceOf<RedirectToRouteResult>(result);
             

        }
        [Test]
        public void PostRegistroAgenteErrorIsOk()
        {
            var IUsuarioServiceMock = new Mock<IUsuarioService>();
            var IValidacionUsuarioMock = new Mock<IValidacionUsuario>();
            var IAuthServiceMock = new Mock<IAuthService>();
            var IInmuebleServiceMock = new Mock<IInmuebleService>();
            var IImageServiceMock = new Mock<IImageService>();
            var ICloudinaryServiceMock = new Mock<ICloudinaryService>();
            var temp = new Usuario() { UsuarioId = 1, Nombre = "prueba", TipoUsuario = "ADMINISTRADOR" };
            IAuthServiceMock.Setup(x => x.GetLogedUser()).Returns(temp);
            var usuario = new UsuarioController(IUsuarioServiceMock.Object, IValidacionUsuarioMock.Object, IAuthServiceMock.Object, IInmuebleServiceMock.Object, IImageServiceMock.Object, ICloudinaryServiceMock.Object);

            usuario.ModelState.AddModelError("Error","ViewModelError");

            var result = usuario.RegistroAgente(new UsuarioViewModel()) as ViewResult;

            Assert.IsInstanceOf<ViewResult>(result);


        }
        [Test]
        public void GetListaUsuariosIsOk() {
            var IUsuarioServiceMock = new Mock<IUsuarioService>();
            var IValidacionUsuarioMock = new Mock<IValidacionUsuario>();
            var IAuthServiceMock = new Mock<IAuthService>();
            var IInmuebleServiceMock = new Mock<IInmuebleService>();
            var IImageServiceMock = new Mock<IImageService>();
            var ICloudinaryServiceMock = new Mock<ICloudinaryService>();
         
            var temp = new Usuario() { UsuarioId = 1, Nombre = "prueba", TipoUsuario = "ADMINISTRADOR" };
            IAuthServiceMock.Setup(x => x.GetLogedUser()).Returns(temp);
            var usuario = new UsuarioController(IUsuarioServiceMock.Object, IValidacionUsuarioMock.Object, IAuthServiceMock.Object, IInmuebleServiceMock.Object, IImageServiceMock.Object, ICloudinaryServiceMock.Object);
            var result = usuario.ListaUsuarios() as ViewResult;

            Assert.IsInstanceOf<ViewResult>(result);
           
        }
        [Test]
        public void GetListaUsuariosErrorIsOk()
        {
            var IUsuarioServiceMock = new Mock<IUsuarioService>();
            var IValidacionUsuarioMock = new Mock<IValidacionUsuario>();
            var IAuthServiceMock = new Mock<IAuthService>();
            var IInmuebleServiceMock = new Mock<IInmuebleService>();
            var IImageServiceMock = new Mock<IImageService>();
            var ICloudinaryServiceMock = new Mock<ICloudinaryService>();
           
            var temp = new Usuario() { UsuarioId = 1, Nombre = "prueba", TipoUsuario = "USUARIO" };
            IAuthServiceMock.Setup(x => x.GetLogedUser()).Returns(temp);
            var usuario = new UsuarioController(IUsuarioServiceMock.Object, IValidacionUsuarioMock.Object, IAuthServiceMock.Object, IInmuebleServiceMock.Object, IImageServiceMock.Object, ICloudinaryServiceMock.Object);
            var result = usuario.ListaUsuarios();

            Assert.IsInstanceOf<RedirectToRouteResult>(result);
        }
        [Test]
        public void GetListaAgentesIsOk()
        {
            var IUsuarioServiceMock = new Mock<IUsuarioService>();
            var IValidacionUsuarioMock = new Mock<IValidacionUsuario>();
            var IAuthServiceMock = new Mock<IAuthService>();
            var IInmuebleServiceMock = new Mock<IInmuebleService>();
            var IImageServiceMock = new Mock<IImageService>();
            var ICloudinaryServiceMock = new Mock<ICloudinaryService>();
            var temp = new Usuario() { UsuarioId = 1, Nombre = "prueba", TipoUsuario = "ADMINISTRADOR" };

            IAuthServiceMock.Setup(x => x.GetLogedUser()).Returns(temp);
            var usuario = new UsuarioController(IUsuarioServiceMock.Object, IValidacionUsuarioMock.Object, IAuthServiceMock.Object, IInmuebleServiceMock.Object, IImageServiceMock.Object, ICloudinaryServiceMock.Object);
            var result = usuario.ListaAgentes();

            Assert.IsInstanceOf<ViewResult>(result);
        }
        [Test]
        public void GetListaAgentesErrorIsOk()
        {
            var IUsuarioServiceMock = new Mock<IUsuarioService>();
            var IValidacionUsuarioMock = new Mock<IValidacionUsuario>();
            var IAuthServiceMock = new Mock<IAuthService>();
            var IInmuebleServiceMock = new Mock<IInmuebleService>();
            var IImageServiceMock = new Mock<IImageService>();
            var ICloudinaryServiceMock = new Mock<ICloudinaryService>();
            var temp = new Usuario() { UsuarioId = 1, Nombre = "prueba", TipoUsuario = "USUARIO" };

            IAuthServiceMock.Setup(x => x.GetLogedUser()).Returns(temp);
            var usuario = new UsuarioController(IUsuarioServiceMock.Object, IValidacionUsuarioMock.Object, IAuthServiceMock.Object, IInmuebleServiceMock.Object, IImageServiceMock.Object, ICloudinaryServiceMock.Object);
            var result = usuario.ListaAgentes();

            Assert.IsInstanceOf<RedirectToRouteResult>(result);
        }
        [Test]
        public void GetUserIsOk()
        {
            var IUsuarioServiceMock = new Mock<IUsuarioService>();
            var IValidacionUsuarioMock = new Mock<IValidacionUsuario>();
            var IAuthServiceMock = new Mock<IAuthService>();
            var IInmuebleServiceMock = new Mock<IInmuebleService>();
            var IImageServiceMock = new Mock<IImageService>();
            var ICloudinaryServiceMock = new Mock<ICloudinaryService>();
        
            var usuario = new Usuario() { UsuarioId = 1, Nombre = "", ApellidoP = "", ApellidoM = "", FechaNacimiento = DateTime.Now, Email = "xd@xd.com", Password = "", Sexo = "" , TipoUsuario="ADMINISTRADOR"};
            IAuthServiceMock.Setup(x => x.GetLogedUser()).Returns(usuario);
            IUsuarioServiceMock.Setup(x => x.GetUsuarioByID(usuario.UsuarioId)).Returns(usuario);
            
            var usuarioc = new UsuarioController(IUsuarioServiceMock.Object, IValidacionUsuarioMock.Object, IAuthServiceMock.Object, IInmuebleServiceMock.Object, IImageServiceMock.Object, ICloudinaryServiceMock.Object);
            var result = usuarioc.GetUser() as ViewResult;

            Assert.IsInstanceOf<ViewResult>(result);
            Assert.AreEqual(result.ViewBag.UserLogged,"ADMINISTRADOR");
        }
        [Test]
        public void GetUserIsOkpost()
        {
            var IUsuarioServiceMock = new Mock<IUsuarioService>();
            var IValidacionUsuarioMock = new Mock<IValidacionUsuario>();
            var IAuthServiceMock = new Mock<IAuthService>();
            var IInmuebleServiceMock = new Mock<IInmuebleService>();
            var IImageServiceMock = new Mock<IImageService>();
            var ICloudinaryServiceMock = new Mock<ICloudinaryService>();
            var imgperfil = new Mock<HttpPostedFileBase>();

            var usuario = new Usuario() { UsuarioId = 1, Nombre = "", ApellidoP = "", ApellidoM = "", FechaNacimiento = DateTime.Now, Email = "xd@xd.com", Password = "", Sexo = "" };
            IAuthServiceMock.Setup(x => x.GetLogedUser()).Returns(usuario);
            IUsuarioServiceMock.Setup(x => x.GetUsuarioByID(usuario.UsuarioId)).Returns(usuario);
            var usuarioc = new UsuarioController(IUsuarioServiceMock.Object, IValidacionUsuarioMock.Object, IAuthServiceMock.Object, IInmuebleServiceMock.Object, IImageServiceMock.Object, ICloudinaryServiceMock.Object);
            
            
            var result = usuarioc.GetUser(usuario, imgperfil.Object);

            
            Assert.IsInstanceOf<RedirectToRouteResult>(result);
        }
        [Test]
        public void GetUserErrorIsOkpost()
        {
            var IUsuarioServiceMock = new Mock<IUsuarioService>();
            var IValidacionUsuarioMock = new Mock<IValidacionUsuario>();
            var IAuthServiceMock = new Mock<IAuthService>();
            var IInmuebleServiceMock = new Mock<IInmuebleService>();
            var IImageServiceMock = new Mock<IImageService>();
            var ICloudinaryServiceMock = new Mock<ICloudinaryService>();
            var imgperfil = new Mock<HttpPostedFileBase>();

            var usuario = new Usuario() { UsuarioId = 1, Nombre = "", ApellidoP = "", ApellidoM = "", FechaNacimiento = DateTime.Now, Email = "xd@xd.com", Password = "", Sexo = "", TipoUsuario= "ADMINISTRADOR" };
            IAuthServiceMock.Setup(x => x.GetLogedUser()).Returns(usuario);
            IUsuarioServiceMock.Setup(x => x.GetUsuarioByID(usuario.UsuarioId)).Returns(usuario);
            var usuarioc = new UsuarioController(IUsuarioServiceMock.Object, IValidacionUsuarioMock.Object, IAuthServiceMock.Object, IInmuebleServiceMock.Object, IImageServiceMock.Object, ICloudinaryServiceMock.Object);
            usuarioc.ModelState.AddModelError("Error","usuario invalido");

            var result = usuarioc.GetUser(usuario, imgperfil.Object) as ViewResult;


            Assert.IsInstanceOf<ViewResult>(result);
            Assert.AreEqual(result.ViewBag.UserLogged , "ADMINISTRADOR");
        }

    }
}
