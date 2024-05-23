using Microsoft.EntityFrameworkCore;
using TECHNICALTASK.Models;
using TECHNICALTASK.Repository;

namespace Infrastructure.Repositories
{

    public class MasterRepositoryAsync : GenericRepositoryAsync<MasterTable>, IMasterRepositoryAsync
    {
        private readonly DbSet<MasterTable> _masterTables;

        public MasterRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _masterTables = dbContext.Set<MasterTable>();
        }

        
    }
}
