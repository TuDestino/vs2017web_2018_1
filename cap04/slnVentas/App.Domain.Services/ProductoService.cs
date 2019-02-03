using App.Data.Repository;
using App.Entities.Base;
using App.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services
{
    public class ProductoService : IProductoService
    {
        public IEnumerable<Producto> GetAll(string nombre, int? categoriaId, int? marcaId)
        {
            List<Producto> results;
            var includes = new List<string>() { "Categoria", "Marca" };
            using (var unitOfWork = new AppUnitOfWork())
            {
                results = unitOfWork.ProductoRepository

                    .GetAll(item => item.Nombre.Contains(nombre) && (categoriaId == null || item.CategoriaID == categoriaId)
                               && (marcaId == null || item.MarcaID == marcaId)
                            , includes)
                    .ToList();
            }
            return results;
        }

        public Producto GetById(int id)
        {
            Producto result;
            using (var unitOfWork = new AppUnitOfWork())
            {
                result = unitOfWork.ProductoRepository.GetById(id);
            }
            return result;
        }

        public bool Save(Producto entity)
        {
            bool result = false;

            try
            {
                using (var unitOfWork = new AppUnitOfWork())
                {
                    if (entity.ProductoID == 0)
                    {
                        unitOfWork.ProductoRepository.Add(entity);
                    }
                    else
                    {
                        unitOfWork.ProductoRepository.Update(entity);
                    }
                    unitOfWork.Complete();
                }

                result = true;
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }
    }
}
