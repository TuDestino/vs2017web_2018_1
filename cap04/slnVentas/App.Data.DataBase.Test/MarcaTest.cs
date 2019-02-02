using System;
using System.Linq;
using App.Entities.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Data.DataBase.Test
{
    [TestClass]
    public class MarcaTest
    {
        [TestMethod]
        public void NuevaMarca()
        {
            using (var model = new AppModel())
            {
                var marca = new Marca()
                { Nombre = "Genius2", Descripcion = "genius coporativo", Estado = true };

                model.Marca.Add(marca);
                model.SaveChanges();

                //verificando que se este creando la categoria
                Assert.IsTrue(marca.MarcaID > 0);
            }
        }

        [TestMethod]
        public void VerificarRegistros()
        {
            using (var model = new AppModel())
            {
                var cantidad = model.Marca.Count();
                Assert.IsTrue(cantidad > 0);
            }
        }
    }
}
