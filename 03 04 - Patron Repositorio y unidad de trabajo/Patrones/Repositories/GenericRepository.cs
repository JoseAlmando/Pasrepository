using Patrones.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Patrones.Repositories
{
    public class GenericRepository<ExampleDataModelo>
     where ExampleDataModelo : class
    {

        private readonly Model1 context;
        private readonly DbSet<ExampleDataModelo> dbSet;

        public GenericRepository(Model1 context)
        {
            this.context = context;
            this.dbSet = context.Set<ExampleDataModelo>();
        }
        public void Create(ExampleDataModelo entity)
        {
            dbSet.Add(entity);
        }
        public void CreateRange(IEnumerable<ExampleDataModelo> entities)
        {
            foreach (var entity in entities)
            {
                Create(entity);
            }
        }
        public async Task<ExampleDataModelo> FindAsync(params object[] keyValues)
        {
            return await dbSet.FindAsync(keyValues);
        }
        public virtual IQueryable<ExampleDataModelo> SelectQuery(string query, params object[] parameters)
        {
            return dbSet.SqlQuery(query, parameters).AsQueryable();
        }
        public void Update(ExampleDataModelo entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }
        public void Delete(ExampleDataModelo entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
        }
        public async Task Delete(params object[] id)
        {
            ExampleDataModelo entity = await this.FindAsync(id);
            if (entity != null)
            {
                this.Delete(entity);
            }
        }
        public IQueryable<ExampleDataModelo> Queryable()
        {
            return dbSet;
        }

    }
}