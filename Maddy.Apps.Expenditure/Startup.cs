using Maddy.Apps.Expenditure.DataProvider.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Maddy.Apps.Expenditure.Business.Infrastructure.Extensions;
using Maddy.Apps.Expenditure.DataProvider.Infrastructure.Extensions;
using AutoMapper;

namespace Maddy.Apps.Expenditure
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
            var connectionString = this.Configuration.GetConnectionString("Expenditure");

            services.AddDbContext<ExpenditureContext>(options => options.UseSqlServer(connectionString));

            services.AddBusinessDI();

            services.AddDataProviderDI();

            services.AddAutoMapper();

            services.AddCors();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            if (this.Configuration.GetSection("cors:origins").Exists())
            {
                app.UseCors(builder =>
                                    builder.WithOrigins(this.Configuration.GetSection("cors:origins").Get<string[]>())
                                            .AllowAnyHeader()
                                            .AllowAnyMethod()
                                            .AllowCredentials());
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
