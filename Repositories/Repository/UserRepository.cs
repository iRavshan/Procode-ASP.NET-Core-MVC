using Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public class UserRepository : GenericRepository<IdentityUser>, IUserRepository
    {
        public UserRepository(AppDbContext dbContext, ILogger logger) : base(dbContext, logger) { }

        public override async Task<IEnumerable<IdentityUser>> GetAll()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{Repo} All function error", typeof(UserRepository));
                return new List<IdentityUser>();
            }
        }

        public override async Task<bool> Update(IdentityUser entity)
        {
            try
            {
                var existingUser = await dbSet.Where(x => x.Id == entity.Id).FirstOrDefaultAsync();

                if (existingUser == null)
                    return await Create(entity);

                existingUser.Email = entity.Email;

                existingUser.UserName = entity.UserName;

                return true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{Repo} Upsert function error", typeof(UserRepository));
                return false;
            }

        }

        public override async Task<bool> Delete(Guid id)
        {
            try
            {
                var exist = await dbSet.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();

                if (exist == null) return false;

                dbSet.Remove(exist);

                return true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{Repo} Delete function error", typeof(UserRepository));
                return false;
            }
        }

    }
}
