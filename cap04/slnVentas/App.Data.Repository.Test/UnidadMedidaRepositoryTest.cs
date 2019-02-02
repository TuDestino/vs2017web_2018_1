﻿using System;
using App.Data.DataBase;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Data.Repository.Test
{
    [TestClass]
    public class UnidadMedidaRepositoryTest
    {
        [TestMethod]
        public void ExistenRegistros()
        {
            var model = new AppModel();
            using (var unitOfWork = new AppUnitOfWork(model))
            {
                var cantidad = unitOfWork.UnidadMedidaRepository.Count();
                Assert.IsTrue(cantidad > 0);
            }
        }
    }
}
