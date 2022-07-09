using Finanzas.Models;
using Finanzas.Repositorio;
using Finanzas.Test.Helper;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Finanzas.Test.ReposTest
{
    [TestFixture]
    public class ReposTest
    {
        IQueryable<Cuenta> data;
        [SetUp]
        public void Setup()
        {
            var date1 = new DateTime(2008, 5, 1, 8, 30, 52);
            data = new List<Cuenta>
           {
               new() {Id = 1, IdCategoria = 1, IdMoneda  = 1,  Nombre ="aaaaaa",  Saldo=100,    Limite=0},
               new() {Id = 1, IdCategoria = 1, IdMoneda  = 1,  Nombre ="aaaaaa",  Saldo=100,    Limite=0},
               new() {Id = 1, IdCategoria = 1, IdMoneda  = 1,  Nombre ="aaaaaa",  Saldo=100,    Limite=0}
              }.AsQueryable();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
        [Test]
        public void GetCategorias()
        {
            var mockDbSetUsuario = new MockDBSet<Cuenta>(data);
            var mockDB = new Mock<ContextoFinanzas>();
            //mockDB.Setup(o => o._Usuarios).Returns(mockDbSetUsuario.Object);

            var repo = new CuentaRepositorio(mockDB.Object);
            var rpta = repo.GetCategorias();
            Assert.IsNotNull(rpta);
        }
    }
}
