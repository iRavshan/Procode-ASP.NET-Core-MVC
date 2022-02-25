using Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected AppDbContext dbContext;
        internal DbSet<T> dbSet;
        public readonly ILogger logger;

        public GenericRepository(AppDbContext dbContext, ILogger logger)
        {
            this.dbContext = dbContext;
            dbSet = dbContext.Set<T>();
            this.logger = logger;
        }

        public virtual async Task<bool> Create(T entity)
        {
            await dbSet.AddAsync(entity);

            return true;
        }

        public virtual Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public virtual Task<IEnumerable<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        public virtual async Task<T> GetById(Guid id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual Task<bool> Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
