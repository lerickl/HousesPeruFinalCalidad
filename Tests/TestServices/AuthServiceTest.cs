using HousesPeru.DB;
using HousesPeru.Models;
using HousesPeru.services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.TestServices
{
    [TestFixture]
    public class AuthServiceTest
    {
        //[Test]
        //public void LoinAuthServiceIsOk()
        //{
        //    var usuario = new Usuario() { UsuarioId = 1, Nombre = "admin", Password = "admin", Email = "admin@admin.com" };
        //    var AuthServiceMock = new Mock<IAuthService>();
        //    var data = new List<Usuario> {
        //        new Usuario { UsuarioId = 1, Nombre = "admin",Password="admin",Email="admin@admin.com"},
        //        new Usuario { UsuarioId = 2, Nombre = "usuario",Password="usuario",Email="Usuario@usuario.com"},

        //    }.AsQueryable();
        //    var dbset = new Mock<DbSet<Usuario>>();

        //    dbset.As<IQueryable<Usuario>>().Setup(m => m.Provider).Returns(data.Provider);
        //    dbset.As<IQueryable<Usuario>>().Setup(m => m.Expression).Returns(data.Expression);
        //    dbset.As<IQueryable<Usuario>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());


        //    var context = new Mock<HousesInPeruContext>();
        //    context.Setup(x => x.Usuarios).Returns(dbset.Object);
        //    var service = new AuthService(context.Object);
        //    var admins = service.Login(usuario);

        //    Assert.AreEqual("admin", admins.Nombre);
        //}

    }
}
