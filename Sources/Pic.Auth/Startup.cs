// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace Pic.Auth
{
    using System.Reflection;
    using IdentityServer4.EntityFramework.Storage;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Pic.Auth.Migrations;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var migrationsAssembly = typeof(AuthDbContext).GetTypeInfo().Assembly.GetName().Name;
            var connectionString = Configuration.GetConnectionString("AuthDatabase");

            services.AddDbContext<AuthDbContext>(opt => opt.UseSqlServer(connectionString, sql => sql.MigrationsAssembly(migrationsAssembly)));

            // services.AddConfigurationDbContext();

            // services.AddScoped<Action<SqlServerDbContextOptionsBuilder>>(op => op.sq )
            // uncomment, if you want to add an MVC-based UI
            // services.AddControllersWithViews();
            //var builder = services.AddIdentityServer()
            //   .AddConfigurationStore(options =>
            //   {
            //       options.ConfigureDbContext = b => b.UseSqlServer(connectionString,
            //           sql => sql.MigrationsAssembly(migrationsAssembly));
            //   })
            //   .AddOperationalStore(options =>
            //   {
            //       options.ConfigureDbContext = b => b.UseSqlServer(connectionString,
            //           sql => sql.MigrationsAssembly(migrationsAssembly));
            //   });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AuthDbContext context)
        {
            context.Database.Migrate();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting();

            app.UseIdentityServer();

            app.UseAuthorization();

            // app.UseEndpoints(endpoints => endpoints.MapDefaultControllerRoute());
        }
    }
}