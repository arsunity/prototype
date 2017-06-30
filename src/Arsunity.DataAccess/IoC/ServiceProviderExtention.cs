using Arsunity.DataAccess.DataContexts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Arsunity.Interfaces.DataAccess.Interfaces;
using Arsunity.DataAccess.DataInitializers;

namespace Arsunity.DataAccess.IoC
{
    public static class ServiceProviderExtention
    {
        public static void AddDataAccessServices(this IServiceCollection services, string connection )
        {
            services.AddDbContext<PrototypeDbContext>(options => options.UseSqlServer(connection));
            services.AddTransient<IDataInitializer, DataInitializer>();
            services.AddTransient<IUserDataAccessor, DataAccessors.UserDataAccessor>();
        }
    }
}
