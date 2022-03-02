using Contracts;
using Microsoft.Extensions.Logging;
using Repositories.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RepositoryManager : IRepositoryManager, IDisposable
    {
        private readonly AppDbContext dbContext;

        private readonly ILogger logger;

        public IUserRepository Users { get; private set; }

        public IContentRepository Contents { get; private set; }

        public ISpeakerRepository Speakers { get; private set; }

        public RepositoryManager(AppDbContext dbContext, ILoggerFactory logger)
        {
            this.dbContext = dbContext;

            this.logger = logger.CreateLogger("logs");

            Users = new UserRepository(dbContext, this.logger);

            Contents = new ContentRepository(dbContext, this.logger);

            Speakers = new SpeakerRepository(dbContext, this.logger);

        }

        public async Task CompleteAsync()
        {
            await dbContext.SaveChangesAsync();
        }

        public async void Dispose()
        {
            await dbContext.DisposeAsync();
        }
    }
}
