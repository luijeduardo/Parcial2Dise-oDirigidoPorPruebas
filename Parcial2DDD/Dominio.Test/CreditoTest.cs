using Dominio.Entities;
using NUnit.Framework;
using System;

namespace Dominio.Test
{
    public class CreditoTests
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void ValidarPruebasUnitariasTrueTest()
        {
            Credito _service = new Credito();
            var response = _service.ValidarPruebasUnitarias(9);
            Assert.AreEqual(true, response);
        }
        [Test]
        public void ValidarPruebasUnitariasFalseTest()
        {
            Credito _service = new Credito();
            var response = _service.ValidarPruebasUnitarias(-9);
            Assert.AreEqual(false, response);
        }
        [Test]
        public void MesDePlazoValidoTest()
        {
            Credito _service = new Credito();
            var response = _service.ValidarMesesDePlazo(8);
            Assert.AreEqual("Mes aceptado.", response);
        }
        [Test]
        public void MesDePlazoMenorA1Test()
        {
            Credito _service = new Credito();
            var response = _service.ValidarMesesDePlazo(0);
            Assert.AreEqual("Menor a 1 mes.", response);
        }
        [Test]
        public void MesDePlazoMayorA12Test()
        {
            Credito _service = new Credito();
            var response = _service.ValidarMesesDePlazo(13);
            Assert.AreEqual("Mayor a 12 meses.", response);
        }
        [Test]
        public void ObtenerCuotasTest()
        {
            Credito _service = new Credito(24000000, DateTime.Parse("2019/02/02"), 6, null);
            var response = _service.ObtenerLasCuotas(_service);
            Assert.AreEqual(6, response.Count);
            Assert.AreEqual(4000000, response[0].Precio);
        }
    }
}