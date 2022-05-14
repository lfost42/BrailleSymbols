using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using BrailleSymbols.Data.Data;
using Microsoft.EntityFrameworkCore;
using BrailleSymbols.Data.Repository.IRepository;
using BrailleSymbols.Data.Repository;
using BrailleSymbols.Data.Mapper;

namespace BrailleSymbolsAPI
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(
                    ConnectionService.GetConnectionString(Configuration)));
            services.AddScoped<IAsciiRepository, AsciiRepository>();
            services.AddScoped<ISpecialSymbolsRepository, SpecialSymbolsRepository>();
            services.AddAutoMapper(typeof(BrailleMappings));
            services.AddSwaggerGen(option =>
            {
                OptionsBuilderConfigurationExtensions.SwaggerDoc("BrailleSymbolsOpenAPISpec",
                    new Microsoft.OpenApi.Models.OpenApiInfo()
                    {
                        Title = "SpecialSymbols API",
                        Version = "1"
                    });
            });

            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //    .AddMicrosoftIdentityWebApi(Configuration.GetSection("AzureAdB2C"));

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseSwagger();

            app.UseRouting();

            //app.UseAuthentication();
            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
