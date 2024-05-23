using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TECHNICALTASK.Models;
using TECHNICALTASK.Repository;

namespace Infrastructure.Repositories
{
    public class DetailsRepositoryAsync : GenericRepositoryAsync<DetailsTable>, IDetailsRepositoryAsync
    {
        private readonly DbSet<DetailsTable> _detailsTables;

        public DetailsRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _detailsTables = dbContext.Set<DetailsTable>();
        }

    }
}
