using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Core.Entities;
using Repositories.Repositories.Contracts;
using Services.Services;
using Services.Services.Contracts;
using Repositories.Repositories;
using Core.Exceptions.Base;

namespace MunicipalityTaxesAPI
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
            AddRepositories(services);
            AddServices(services);
            AddDbContext(services);
            AddCorsPolicy(services);

            services.AddHttpContextAccessor();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MunicipalityTaxesAPI", Version = "v1" });
            });
            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MunicipalityTaxesAPI v1"));
            }

            app.UseRouting();
            app.UseCors("CorsPolicy");
            app.UseHttpsRedirection();
            app.UseMiddleware<ApiExceptionMiddleware>();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        #region Private Methods

        private void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IMunicipalityTaxesRepository, MunicipalityTaxesRepository>();
        }

        private void AddServices(IServiceCollection services)
        {
            services.AddScoped<IMunicipalityTaxesService, MunicipalityTaxesService>();
        }

        private void AddDbContext(IServiceCollection services)
        {
            services.AddDbContext<MunicipalitiesDbContext>(options =>
            {
                var connectionString = Configuration.GetConnectionString("MunicipalitiesDb");
                options.UseSqlServer(connectionString);
            });
        }

        private void AddCorsPolicy(IServiceCollection services)
        {
            // For simplicity no CORS policy was implemented
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });
        }

        #endregion
    }
}
