using HousesPeru.Controllers;
using HousesPeru.Models;
using HousesPeru.services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Tests.TestControllers
{
    [TestFixture]
    class PlanControllerTest
    {
        [Test]
        public void IndexIsOk()
        {


            var IAuthServiceMock = new Mock<IAuthService>();
            var IPlanServiceeMock = new Mock<IPlanService>();
            var IUsuarioServiceMock = new Mock<IUsuarioService>();

            var home = new PlanController(IAuthServiceMock.Object, IPlanServiceeMock.Object, IUsuarioServiceMock.Object);


            var result = home.Index() as ViewResult;
            Assert.IsInstanceOf<ViewResult>(result);
            Assert.IsNull(result.ViewBag.UserLogged);



        }
        [Test]
        public void GetPlanesWithUserLoggedIsNull()
        {


            var IAuthServiceMock = new Mock<IAuthService>();
            var IPlanServiceeMock = new Mock<IPlanService>();
            var IUsuarioServiceMock = new Mock<IUsuarioService>();

            var home = new PlanController(IAuthServiceMock.Object, IPlanServiceeMock.Object, IUsuarioServiceMock.Object);


            var result = home.GetPlanes() as ViewResult;
            Assert.IsInstanceOf<ViewResult>(result);
            Assert.IsNull(result.ViewBag.UserLogged);
            Assert.IsNull(result.ViewBag.PlanActual);
            Assert.IsNull(result.ViewBag.User);
      

        }
        [Test]
        public void GetPlanesWithUserLoggedIsNotNull()
        {


            var IAuthServiceMock = new Mock<IAuthService>();
            var IPlanServiceeMock = new Mock<IPlanService>();
            var IUsuarioServiceMock = new Mock<IUsuarioService>();
            var temp = new Usuario()
            {
                UsuarioId=1,
                Nombre = "Erick",
                TipoUsuario = "USUARIO",
                PlanId= 1

            };
            var tempPlan = new Plan();
            IAuthServiceMock.Setup(x => x.GetLogedUser()).Returns(temp);
            IPlanServiceeMock.Setup(x => x.getPlanById(temp.PlanId)).Returns(tempPlan);
            IUsuarioServiceMock.Setup(x => x.GetUsuarioByID(temp.UsuarioId)).Returns(temp);
            var home = new PlanController(IAuthServiceMock.Object, IPlanServiceeMock.Object, IUsuarioServiceMock.Object);


            var result = home.GetPlanes() as ViewResult;


            Assert.IsInstanceOf<ViewResult>(result);
            Assert.AreEqual(result.ViewBag.UserLogged, "USUARIO");
            Assert.AreEqual(result.ViewBag.PlanActual, tempPlan);
            Assert.AreEqual(result.ViewBag.User, temp);


        }
        [Test]
        public void PostPlanesIsOk()
        {


            var IAuthServiceMock = new Mock<IAuthService>();
            var IPlanServiceeMock = new Mock<IPlanService>();
            var IUsuarioServiceMock = new Mock<IUsuarioService>();

            var home = new PlanController(IAuthServiceMock.Object, IPlanServiceeMock.Object, IUsuarioServiceMock.Object);


            var result = home.PostPlanes(1) as ViewResult;
            Assert.IsInstanceOf<ViewResult>(result);
            Assert.IsNull(result.ViewBag.UserLogged);
            Assert.IsNull(result.ViewBag.PlanActual);
            Assert.IsNull(result.ViewBag.User);


        }

    }
}
