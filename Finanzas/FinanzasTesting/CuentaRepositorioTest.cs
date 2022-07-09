using Finanzas.Models;
using Finanzas.Repositorio;
using FinanzasTesting.Helper;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinanzasTesting
{
    [TestFixture]
    public class CuentaRepositorioTest
    {
        IQueryable<Categoria> data;
        IQueryable<Moneda> moneda;
        IQueryable<Cuenta> cuenta;
        [SetUp]
        public void Setup()
        {
            var date1 = new DateTime(2008, 5, 1, 8, 30, 52);
            data = new List<Categoria>
           {
               new() {Id = 1, Nombre ="Propio"},
               new() {Id = 1, Nombre ="Credito"},
               }.AsQueryable();

            moneda = new List<Moneda>
           {
               new() {Id = 1, Nombre ="Propio"},
               new() {Id = 1, Nombre ="Credito"},
               }.AsQueryable();

            cuenta = new List<Cuenta>
           {
                new() {Id = 1, IdCategoria = 1, IdMoneda  = 1,  Nombre ="aaaaaa",  Saldo=100,    Limite=0},
               new() {Id = 1, IdCategoria = 1, IdMoneda  = 1,  Nombre ="aaaaaa",  Saldo=100,    Limite=0},
               new() {Id = 1, IdCategoria = 1, IdMoneda  = 1,  Nombre ="aaaaaa",  Saldo=100,    Limite=0}
             }.AsQueryable();
        }
        [Test]
        public void GetCategorias()
        {
            var mockDbSetCategoria = new MockDBSet<Categoria>(data);
            var mockDB = new Mock<ContextoFinanzas>();
            mockDB.Setup(o => o.Categorias).Returns(mockDbSetCategoria.Object);

            var repo = new CuentaRepositorio(mockDB.Object);
            var rpta = repo.GetCategorias();
            Assert.IsNotNull(rpta);
        }

        [Test]
        public void GetMoneda()
        {
            var mockDbSetmoneda = new MockDBSet<Moneda>(moneda);
            var mockDB = new Mock<ContextoFinanzas>();
            mockDB.Setup(o => o.Monedas).Returns(mockDbSetmoneda.Object);

            var repo = new CuentaRepositorio(mockDB.Object);
            var rpta = repo.GetMoneda();
            Assert.IsNotNull(rpta);
        }

        [Test]
        public void GetCuentas()
        {
            var mockDbSetCuenta = new MockDBSet<Cuenta>(cuenta);
            var mockDB = new Mock<ContextoFinanzas>();
            mockDB.Setup(o => o.Cuentas).Returns(mockDbSetCuenta.Object);

            var repo = new CuentaRepositorio(mockDB.Object);
            var rpta = repo.GetCuentas();
            Assert.IsNotNull(rpta);
        }
        [Test]
        public void SaveCuenta()
        {
            var mockDbSetCuenta = new MockDBSet<Cuenta>(cuenta);
            var mockDB = new Mock<ContextoFinanzas>();
            mockDB.Setup(o => o.Cuentas).Returns(mockDbSetCuenta.Object);

            var repo = new CuentaRepositorio(mockDB.Object);
            var cuentita = new Cuenta(){ Id = 1, IdCategoria = 1, IdMoneda = 1, Nombre = "aaaaaa", Saldo = 100, Limite = 0 };
            repo.SaveCuenta(cuentita);
            mockDbSetCuenta.Verify(o => o.Add(cuentita), Times.Once());

        }
    }


     
}
