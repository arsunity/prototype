// ReSharper disable ClassNeverInstantiated.Global
namespace Arsunity.Prototype
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Configuration;
    using Arsunity.DataAccess.IoC;
    using Arsunity.Interfaces.DataAccess.Interfaces;
    using System.Linq;

    /// <summary>
    /// The startup.
    /// </summary>
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; set; }

        /// <summary>
        /// The configure services.
        /// </summary>
        /// <param name="services">
        /// The services.
        /// </param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDataAccessServices(Configuration.GetConnectionString("PrototypeConnection"));
            services.AddMvc();
        }

        /// <summary>
        /// The configure.
        /// </summary>
        /// <param name="app">
        /// The app.
        /// </param>
        /// <param name="env">
        /// The env.
        /// </param>
        /// <param name="loggerFactory">
        /// The logger factory.
        /// </param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var options = new DefaultFilesOptions();
            options.DefaultFileNames.Clear();
            options.DefaultFileNames.Add("start.html");
            app.UseDefaultFiles(options);
            app.UseStaticFiles();

            var userServices = app.ApplicationServices.GetService<IUserDataAccessor>();
            var users = userServices.GetAllUsers().ToList();

            app.UseMvc(
                routes =>
                    {
                        routes.MapRoute(
                            name: "default", 
                            template: "{controller=Home}/{action=Index}/{id?}");
                    });

            app.Run(async context =>
            {
                await context.Response.WriteAsync($"Arsunity empty!");
            });
        }
    }
}
