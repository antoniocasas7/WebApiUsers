using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using WebApiUsers.Controllers;
using WebApiUsers.Models.Entidades;

namespace WebApiUsers.WebApiTest
{
    /// <summary>
    /// Descripción resumida de PersonaQueryTest
    /// </summary>
    [TestClass]
    public class UserRepositoryTest
    {

        public int idUserPrueba = 1;


        /// <summary>
        /// Prueba para comprobar que hay datos en la base de datos
        /// </summary>
        [TestMethod]
        public void GetAll()
        {
            User usuario = new User { Id = 1, Name = "Juan Garcia", CreateDate = DateTime.Now.Date, UpdateDate = DateTime.Now.Date };

             using (var mock = AutoMock.GetLoose())
            {
                // Arrange - configure the mock
                var cuenta = mock.Mock<IUserRepository>().Setup(x => x.GetAll()).Returns(It.IsAny<List<User>>());

                var sut = mock.Create<UserRepository>();

                // Act
                var actual = sut.GetAll();

                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreNotEqual(0, actual.Count);
            }
        }


        /// <summary>
        /// Prueba para comprobar que el usuario de Id concreto es correcto
        /// </summary>
        [TestMethod]
        public void GetById()
        {
            User usuario = new User { Id = 1, Name = "Juan Garcia", CreateDate = DateTime.Now.Date, UpdateDate = DateTime.Now.Date };

            using (var mock = AutoMock.GetLoose())
            {
             
                mock.Mock<IUserRepository>().Setup(x => x.GetById(idUserPrueba)).Returns(usuario);
           
                // Creamos una instancia del mock y la inyectamos a la capa superior
                var sut = new UserController(mock.Mock<IUserRepository>().Object);
                // Act
                var actual = sut.GetUserById(idUserPrueba);

                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(usuario, actual);
            }
        }

    }
}