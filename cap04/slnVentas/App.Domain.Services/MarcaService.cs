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
    public class MarcaService : IMarcaService
    {
        public IEnumerable<Marca> GetAll(string nombre)
        {
            List<Marca> results;
            using (var unitOfWork = new AppUnitOfWork())
            {
                results = unitOfWork.MarcaRepository.GetAll(
                    item => item.Nombre.Contains(nombre))
                    .ToList();
            }
            return results;
        }

        public Marca GetById(int id)
        {
            Marca result;
            using (var unitOfWork = new AppUnitOfWork())
            {
                result = unitOfWork.MarcaRepository.GetById(id);
            }
            return result;
        }

        public bool Save(Marca entity)
        {
            bool result = false;

            try
            {
                using (var unitOfWork = new AppUnitOfWork())
                {
                    if (entity.MarcaID == 0)
                    {
                        unitOfWork.MarcaRepository.Add(entity);
                    }
                    else
                    {
                        unitOfWork.MarcaRepository.Update(entity);
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
