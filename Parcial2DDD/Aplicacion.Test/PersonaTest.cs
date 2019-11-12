using Dominio.Entities;
using Infraestructura;
using Infraestructura.Base;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Aplicacion.Test
{
    public class PersonaTest
    {
        private ParcialContext _context;
        [SetUp]
        public void Setup()
        {
            var optionsSqlServer = new DbContextOptionsBuilder<ParcialContext>()
             .UseSqlServer("Server=DESKTOP-GP31J4O;Database=Parcial;Trusted_Connection=True;MultipleActiveResultSets=true")
             .Options;
            _context = new ParcialContext(optionsSqlServer);

            //var optionsInMemory = new DbContextOptionsBuilder<ParcialContext>().UseInMemoryDatabase("Parcial").Options;
            //_context = new ParcialContext(optionsInMemory);

        }
        [Test]
        public void RegistrarUsuarioTest()
        {
            var request = new Personarequest() { Cedula = "123", Nombres = "Luis E." };
            RegistrarPersonaService _service = new RegistrarPersonaService(new UnitOfWork(_context));
            var response = _service.Ejecutar(request);
            Assert.AreEqual("Se registró la persona.", response.Mensaje);
        }
        [Test]
        public void UsuarioARegistrarYaExisteTest()
        {
            var request = new Personarequest() { Cedula = "123", Nombres = "Andres B.C" };
            RegistrarPersonaService _service = new RegistrarPersonaService(new UnitOfWork(_context));
            var response = _service.Ejecutar(request);
            Assert.AreEqual("La persona ya existe.", response.Mensaje);
        }
    }
}
