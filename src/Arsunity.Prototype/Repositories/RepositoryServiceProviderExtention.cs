namespace Arsunity.Prototype.Repositories
{
    using Arsunity.Interfaces.Repositories;

    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// The repository service provider extention.
    /// </summary>
    public static class RepositoryServiceProviderExtention
    {
        /// <summary>
        /// The add repository services.
        /// </summary>
        /// <param name="services">
        /// The services.
        /// </param>
        public static void AddRepositoryServices(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
        }
    }
}
