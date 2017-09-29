namespace Arsunity.DataAccess.IoC
{
    using Arsunity.DataAccess.DataContexts;
    using Arsunity.DataAccess.DataInitializers;
    using Arsunity.Interfaces.DataAccess.Interfaces;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// The service provider extention.
    /// </summary>
    public static class ServiceProviderExtention
    {
        /// <summary>
        /// The add data access services.
        /// </summary>
        /// <param name="services">
        /// The services.
        /// </param>
        /// <param name="connection">
        /// The connection.
        /// </param>
        public static void AddDataAccessServices(this IServiceCollection services, string connection)
        {
            services.AddDbContext<PrototypeDbContext>(options => options.UseSqlServer(connection));
            services.AddTransient<IDataInitializer, DataInitializer>();
            services.AddTransient<IUserDataAccessor, DataAccessors.UserDataAccessor>();
        }
    }
}
