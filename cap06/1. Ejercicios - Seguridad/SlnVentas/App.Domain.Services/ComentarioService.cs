using App.Data.Repository;
using App.Domain.Interfaces;
using App.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services
{
   public class ComentarioService : IComentarioService
    {
        public IEnumerable<Comentario> GetAll()
        {
            List<Comentario> result;
            using (var unitOfWork = new AppUnitOfWork())
            {
                result = unitOfWork.ComentarioRepository.GetAll()
                            .ToList();
            }
            return result;
        }

        public void Guardar(Comentario entity)
        {
            using (var uniOfWork = new AppUnitOfWork())
            {
                uniOfWork.ComentarioRepository.Add(entity);
                uniOfWork.Complete();
            }
        }
               
    }
}
