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
    public class ContentRepository : GenericRepository<Content>, IContentRepository
    {
        public ContentRepository(AppDbContext dbContext, ILogger logger) : base(dbContext, logger) { }

        public override async Task<IEnumerable<Content>> GetAll()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{Repo} All function error", typeof(ContentRepository));
                return new List<Content>();
            }
        }

        public override async Task<bool> Update(Content entity)
        {
            try
            {
                var existingUser = await dbSet.Where(x => x.Id == entity.Id).FirstOrDefaultAsync();

                if (existingUser == null)
                    return await Create(entity);

                existingUser.Author = entity.Author;
                existingUser.GitUrl = entity.GitUrl;
                existingUser.LongDescription = entity.LongDescription;
                existingUser.ShortDescription = entity.ShortDescription;
                existingUser.ThumbnailUrl = entity.ThumbnailUrl;
                existingUser.Name = entity.Name;
                existingUser.YoutubeUrl = entity.YoutubeUrl;

                return true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{Repo} Update function error", typeof(ContentRepository));
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
                logger.LogError(ex, "{Repo} Delete function error", typeof(ContentRepository));
                return false;
            }
        }

    }
}
