using Dominio.Entities;
using Infraestructura;
using Infraestructura.Base;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Test
{
    public class CreditoTest
    {
        ParcialContext _context;
        Personarequest personarequest;
        [SetUp]
        public void Setup()
        {

            var optionsSqlServer = new DbContextOptionsBuilder<ParcialContext>()
            .UseSqlServer("Server=DESKTOP-GP31J4O;Database=Parcial;Trusted_Connection=True;MultipleActiveResultSets=true")
            .Options;
            _context = new ParcialContext(optionsSqlServer);

            //var optionsInMemory = new DbContextOptionsBuilder<ParcialContext>().UseInMemoryDatabase("Parcial").Options;
            //_context = new ParcialContext(optionsInMemory);

            personarequest = new Personarequest() { Cedula="123", Nombres = "Luis E." };
        }
        [Test]
        public void RegistrarCreditoTest()
        {
            RegistrarCreditoService _service = new RegistrarCreditoService(new UnitOfWork(_context));
            var response = _service.Ejecutar(personarequest, 12000000, DateTime.Parse("2019/11/07"), 12);
            Assert.AreEqual("Se registró el credito.", response.Mensaje);
        }
        [Test]
        public void RegistrarCreditoIncorrectoTest()
        {
            RegistrarCreditoService _service = new RegistrarCreditoService(new UnitOfWork(_context));
            var response = _service.Ejecutar(personarequest, 12000000, DateTime.Parse("2019/11/07"), -2);
            Assert.AreEqual("No se registró el crédito, falló alguna prueba unitaria.", response.Mensaje);
        }
        [Test]
        public void UsuarioYaConCreditoTest()
        {
            RegistrarCreditoService _service = new RegistrarCreditoService(new UnitOfWork(_context));
            var response = _service.Ejecutar(personarequest, 1200000, DateTime.Parse("2019/11/07"), 5);
            Assert.AreEqual("La persona ya tiene un crédito.", response.Mensaje);
        }
    }
}
