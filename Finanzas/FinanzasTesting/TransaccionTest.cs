using Finanzas.Controllers;
using Finanzas.Models;
using Finanzas.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanzasTesting
{
   
    [TestFixture]
    class TransaccionTest
    {
        [Test]
        public void IndexTest()
        {
            var repo = new Mock<ITransaccionRepositorio>();
            repo.Setup(o => o.GetTransaccions(1)).Returns(new List<Transaccion>());
            repo.Setup(o => o.GetCuenta(1)).Returns(new Cuenta());

            var controller = new TransaccionController(repo.Object);
            var view = controller.Index(1) as ViewResult;

            Assert.AreEqual("Index", view.ViewName);
        }

        [Test]
        public void CrearTestGet()
        {
            var repo = new Mock<ITransaccionRepositorio>();
            repo.Setup(o => o.GetTipos()).Returns(new List<Tipo>());

            var controller = new TransaccionController(repo.Object);
            var view = controller.Crear(1) as ViewResult;

            Assert.AreEqual("Crear", view.ViewName);
        }

        [Test]
        public void CrearTestPostCorrectoIngreso()
        {
            var repo = new Mock<ITransaccionRepositorio>();
            repo.Setup(o => o.GetCuenta(1)).Returns(new Cuenta() { Id = 1 });
            repo.Setup(o => o.SaveTransaccion(new Transaccion()));

            var controller = new TransaccionController(repo.Object);
            var view = controller.Crear(new Transaccion()
            { IdCuenta = 1, IdTipo = 1 }) as RedirectToActionResult;

            Assert.AreEqual("Index", view.ActionName);
        }

        [Test]
        public void CrearTestPostCorrectoEgreso()
        {
            var repo = new Mock<ITransaccionRepositorio>();
            repo.Setup(o => o.GetCuenta(1)).Returns(new Cuenta()
            { Id = 1, Limite = 10, Saldo = 10 });
            repo.Setup(o => o.SaveTransaccion(new Transaccion()));

            var controller = new TransaccionController(repo.Object);
            var view = controller.Crear(new Transaccion()
            { IdCuenta = 1, IdTipo = 2, Monto = 10 }) as RedirectToActionResult;

            Assert.AreEqual("Index", view.ActionName);
        }
        [Test]
        public void CrearEgresoporCOntadoQueseamayor()
        {
            var repo = new Mock<ITransaccionRepositorio>();
            repo.Setup(o => o.GetCuenta(1)).Returns(new Cuenta()
            { Id = 1, Limite = 10, Saldo = 10 });
            repo.Setup(o => o.SaveTransaccion(new Transaccion()));

            var controller = new TransaccionController(repo.Object);
            var view = controller.Crear(new Transaccion()
            { IdCuenta = 1, IdTipo = 2, Monto = 10 }) as RedirectToActionResult;

            Assert.AreEqual("Index", view.ActionName);
        }
    }
}
