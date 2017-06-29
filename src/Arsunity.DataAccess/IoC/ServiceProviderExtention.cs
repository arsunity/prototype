using Arsunity.DataAccess.DataContexts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Arsunity.DataAccess.IoC
{
    public static class ServiceProviderExtention
    {
        public static void AddDataAccessServices(this IServiceCollection services, string connection )
        {
            services.AddDbContext<PrototypeDbContext>(options => options.UseSqlServer(connection));
            services.AddTransient<Interfaces.DataAccess.Interfaces.IUserDataAccessor, DataAccessors.UserDataAccessor>();
        }
    }
}
