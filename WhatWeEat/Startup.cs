using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WhatWeEat.Repositories.Implementations;
using WhatWeEat.Repositories.Interfaces;
using WhatWeEat.Services.Implementations;
using WhatWeEat.Services.Interfaces;

namespace WhatWeEat
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
            services.AddControllersWithViews();
            
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlite(connectionString);
            });
            
            // Services
            services.AddScoped<IMealService, MealService>();
            services.AddScoped<IEatRecordService, EatRecordService>();
            
            // Repositories
            services.AddScoped<IMealRepository, MealRepository>();
            services.AddScoped<IEatRecordRepository, EatRecordRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}