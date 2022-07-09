using Finanzas.Controllers;
using Finanzas.Models;
using Finanzas.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Finanzas.Test.ControllersTest
{
    [TestFixture]
    public class ControladoresTest
    {
          
        [Test]
        public void CuentaIndexTest()
        {
            var repo = new Mock<ICuentaRepositorio>();
            repo.Setup(o => o.GetCuentas()).Returns(new List<Cuenta>());
            repo.Setup(o => o.GetCategorias()).Returns(new List<Categoria>());
            repo.Setup(o => o.GetMoneda()).Returns(new List<Moneda>());

            var controller = new CuentaController(repo.Object);
            var view = controller.Index() as ViewResult;

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
        public void CrearTestPostGoodIngreso()
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
        public void CrearTestPostGoodEgreso()
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
        public void CrearTestPostBadEgreso()
        {
            var repo = new Mock<ITransaccionRepositorio>();
            repo.Setup(o => o.GetCuenta(1)).Returns(new Cuenta()
            { Id = 1, Limite = 10, Saldo = 10 });
            repo.Setup(o => o.SaveTransaccion(new Transaccion()));

            var controller = new TransaccionController(repo.Object);
            var view = controller.Crear(new Transaccion()
            { IdCuenta = 1, IdTipo = 2, Monto = 50 }) as ViewResult;

            Assert.AreEqual("Crear", view.ViewName);
        }
    }
}
