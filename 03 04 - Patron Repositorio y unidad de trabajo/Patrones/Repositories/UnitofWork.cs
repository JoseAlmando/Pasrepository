using Patrones.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Patrones.Repositories
{
    public class UnitOfWork
    {
        public UnitOfWork()
        {
            this.context = new Model1();
        }
        private readonly Model1 context;

        private GenericRepository<Clients> clientsRepository;
        public GenericRepository<Clients> ClientsRepository
        {
            get
            {
                if (this.clientsRepository == null)
                {
                    this.clientsRepository = new GenericRepository<Clients>(this.context);
                }
                return this.clientsRepository;
            }
        }

        public async Task SaveChangesAsync()
        {
            await this.context.SaveChangesAsync();
        }
    }
}