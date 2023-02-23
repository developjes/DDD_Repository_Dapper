using Example.Ecommerce.Application.DTO;
using Example.Ecommerce.Application.Interface;
using Example.Ecommerce.Application.MsTest.ConfigEnvironment;
using Example.Ecommerce.Transversal.Common.Generic;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Example.Ecommerce.Application.MsTest
{
    [TestClass]
    //Nombre clase: [NombreClase]Test
    public class UserApplicationTest
    {
        private static WebApplicationFactory<Program> _factory;
        private static IServiceScopeFactory _scopeFactory;

        [ClassInitialize]
        //Nombre prueba: [Metodo]_[Escenario]_[ResultadoEsperado]
        public static void ClassInitialize(TestContext _)
        {
            _factory = new CustomWebApplicationFactory();
            _scopeFactory = _factory.Services.GetRequiredService<IServiceScopeFactory>();
        }

        [TestMethod]
        //Nombre prueba: [Metodo]_[Escenario]_[ResultadoEsperado]
        public void Authenticate_CuandoNoSeEnvianParametros_RetornarMensajeErrorValidacion()
        {
            using IServiceScope scope = _scopeFactory.CreateScope();
            IUserApplication context = scope.ServiceProvider.GetService<IUserApplication>();

            // Arrange: Donde se inicializan los obj necesarios para la ejecucion del codigo
            string userName = string.Empty;
            string password = string.Empty;
            const string expected = "Parametros no pueden ser vacios";

            // Act: Donde se ejecuta el metodo que se va a probar y se obtiene el resultado
            Response<UserDto> result = context.Authenticate(userName, password);
            string actual = result.Message;

            // Assert:Donde se compueba que el resultao obtenido es el esperado
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Authenticate_CuandoSeEnvianParametrosCorrectos_RetornarMensajeExito()
        {
            using IServiceScope scope = _scopeFactory.CreateScope();
            IUserApplication context = scope.ServiceProvider.GetService<IUserApplication>();

            // Arrange
            const string userName = "JES";
            const string password = "1234";
            const string expected = "Autenticacion exitosa";

            // Act
            Response<UserDto> result = context.Authenticate(userName, password);
            string actual = result.Message;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Authenticate_CuandoSeEnvianParametrosIncorrectos_RetornarMensajeUsuarioNoExiste()
        {
            using IServiceScope scope = _scopeFactory.CreateScope();
            IUserApplication context = scope.ServiceProvider.GetService<IUserApplication>();

            // Arrange
            const string userName = "ALEX";
            const string password = "123456899";
            const string expected = "Usuario no existe";

            // Act
            Response<UserDto> result = context.Authenticate(userName, password);
            string actual = result.Message;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
