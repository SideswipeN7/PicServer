using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pic.Encrypter;
using Pic.Repository;
using Pic.Repository.Models;
using Pic.Server.Automapper;
using Pic.Server.Services;
using Pic.Shared.Configuration;
using Pic.Shared.Interfaces;

namespace Pic.Service
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSingleton(s => Configuration.GetSection(nameof(AppConfiguration)).Get<AppConfiguration>());
            services.AddSingleton(s => CreateMapper());
            services.AddSingleton(new EntitiesMapping());

            services.AddScoped<IEncrypter, Md5Encrypter>();

            services.AddScoped<IRepository<AlbumEntity>, LiteDbRepository<AlbumEntity>>();
            services.AddScoped<IRepository<UserEntity>, LiteDbRepository<UserEntity>>();
            services.AddScoped<IRepository<GroupEntity>, LiteDbRepository<GroupEntity>>();

            services.AddScoped<ICrudService<AlbumEntity>, CrudService<AlbumEntity>>();
            services.AddScoped<ICrudService<UserEntity>, CrudService<UserEntity>>();
            services.AddScoped<ICrudService<GroupEntity>, CrudService<GroupEntity>>();
        }

        private IMapper CreateMapper()
        {
            return new MapperConfiguration(conf =>
                    conf.AddProfile(new MappingProfile())
            ).CreateMapper();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}