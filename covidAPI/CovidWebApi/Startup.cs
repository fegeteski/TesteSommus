using Core.Data;
using Core.Interfaces;
using Core.Interfaces.Countries;
using Core.Services;
using Covid.Application.Interfaces;
using Infrastructure.Repository;
using Infrastructure.Repository.Countrys;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace CovidWebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseMySql(Configuration.GetSection("DefaultConnection").Value.ToString(),
                    new MySqlServerVersion(new Version(8, 0, 11))
                ));
            
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddCors();
            services.AddCors(options => options.AddPolicy("public", policy => {
                policy.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
            }));

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors("public");

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

        }
    }
}
