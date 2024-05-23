using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using TECHNICALTASK.Models;
using TECHNICALTASK.Repository;

namespace Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            #region Repositories
            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            services.AddTransient<IDetailsRepositoryAsync, DetailsRepositoryAsync>();
            services.AddTransient<IMasterRepositoryAsync, MasterRepositoryAsync>();

            #endregion
        }
    }
}
