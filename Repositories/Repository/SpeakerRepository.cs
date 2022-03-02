using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public class SpeakerRepository : GenericRepository<Speaker>, ISpeakerRepository
    {
        public SpeakerRepository(AppDbContext dbContext, ILogger logger) : base(dbContext, logger) { }

        public override async Task<IEnumerable<Speaker>> GetAll()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{Repo} All function error", typeof(SpeakerRepository));
                return new List<Speaker>();
            }
        }

        public override async Task<bool> Update(Speaker entity)
        {
            try
            {
                var existingUser = await dbSet.Where(x => x.Id == entity.Id).FirstOrDefaultAsync();

                if (existingUser == null)
                    return await Create(entity);

                return true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{Repo} Update function error", typeof(SpeakerRepository));
                return false;
            }

        }

        public override async Task<bool> Delete(Guid id)
        {
            try
            {
                var exist = await dbSet.FindAsync(id);
                if (exist == null) return false;
                dbSet.Remove(exist);
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{Repo} Delete function error", typeof(SpeakerRepository));
                return false;
            }
        }

        public override async Task<bool> Create(Speaker entity)
        {
            try
            {
                await dbSet.AddAsync(entity);

                return true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{Repo} Create function error", typeof(SpeakerRepository));
                return false;
            }
        }

        
    }
}
