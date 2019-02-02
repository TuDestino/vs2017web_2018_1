using System;
using System.Linq;
using App.Entities.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Data.DataBase.Test
{
    [TestClass]
    public class UnidadMedidaTest
    {
        [TestMethod]
        public void NuevaUnidadMedida()
        {
            using (var model = new AppModel())
            {
                var unidadMedida = new UnidadMedida()
                { Nombre = "NO numerico"};

                model.UnidadMedida.Add(unidadMedida);
                model.SaveChanges();

                //verificando que se este creando la categoria
                Assert.IsTrue(unidadMedida.UnidadMedidaID > 0);
            }
        }

        [TestMethod]
        public void VerificarRegistros()
        {
            using (var model = new AppModel())
            {
                var cantidad = model.UnidadMedida.Count();
                Assert.IsTrue(cantidad > 0);
            }
        }
    }
}
