using System;
using App.Data.DataBase;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Data.Repository.Test
{
    [TestClass]
    public class MarcaRepositoryTest
    {
        [TestMethod]
        public void ExistenRegistros()
        {
            var model = new AppModel();
            using (var unitOfWork = new AppUnitOfWork(model))
            {
                var cantidad = unitOfWork.MarcaRepository.Count();
                Assert.IsTrue(cantidad > 0);
            }
        }
    }
}
