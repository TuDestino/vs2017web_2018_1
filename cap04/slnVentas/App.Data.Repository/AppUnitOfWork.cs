using App.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repository
{
    public class AppUnitOfWork : IAppUnitOfWork
    {
        private readonly DbContext _context;

        public ICategoriaRepository CategoriaRepository { get; set; }

        public AppUnitOfWork(DbContext context)
        {
            _context = context;
            this.CategoriaRepository = new CategoriaRepository(_context);
        }
                    

        public int Complete()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}