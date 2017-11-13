// ReSharper disable ClassNeverInstantiated.Global
namespace Arsunity.Prototype
{
    using Arsunity.DataAccess.IoC;
    using Arsunity.Interfaces.DataAccess.Interfaces;
    using Arsunity.Interfaces.DataAccess.Models;
    using Arsunity.Prototype.Repositories;
    using Arsunity.Prototype.ViewModels;
    using AutoMapper;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.FileProviders;
    using Microsoft.Extensions.Logging;
    using System.Runtime.Loader;

    /// <summary>
    /// The startup.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="env">
        /// The env.
        /// </param>
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();
            this.Configuration = builder.Build();
        }

        /// <summary>
        /// Gets or sets the configuration.
        /// </summary>
        private IConfiguration Configuration { get; set; }

        /// <summary>
        /// The configure services.
        /// </summary>
        /// <param name="services">
        /// The services.
        /// </param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDataAccessServices(this.Configuration.GetConnectionString("PrototypeConnection"));
            services.AddRepositoryServices();
            var assembly = AssemblyLoadContext.Default.LoadFromAssemblyName(new System.Reflection.AssemblyName(@"Arsunity.Grid"));
            services.AddMvc().AddApplicationPart(assembly).AddRazorOptions(
              o =>
              {
                  o.FileProviders.Add(new EmbeddedFileProvider(assembly, assembly.GetName().Name));
              }
            );
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

            var dataInitializer = app.ApplicationServices.GetService<IDataInitializer>();
            dataInitializer.Init();

            Mapper.Initialize(cfg => { cfg.CreateMap<User, UserVm>(); cfg.CreateMap<UserVm, User>(); cfg.CreateMap<User, GridUserVm>(); cfg.CreateMap<UserVm, GridUserVm>(); });

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
