using HousingEstateManagementSystem.Bll;
using HousingEstateManagementSystem.Dal.Abstract;
using HousingEstateManagementSystem.Dal.Concrete.EntityFramework.Repository;
using HousingEstateManagementSystem.Dal.Concrete.EntityFramework.UnitOfWork;
using HousingEstateManagementSystem.Entity.Models;
using HousingEstateManagementSystem.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HousingEstateManagementSystem.WepApi
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
            services.AddScoped<DbContext, Context>();
            #region ServiceSection
            services.AddScoped<IHouseService, HouseManager>();
            services.AddScoped<IPaymentService, PaymentManager>();
            services.AddScoped<IInvoiceService, InvoiceManager>();
            services.AddScoped<IMessageService, MessageManager>();
            #endregion

            #region RepositorySection
            services.AddScoped<IHouseRepository, HouseRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            services.AddScoped<IMessageRepository, MessageRepository>();
            #endregion

            #region UnitOfWork
            services.AddScoped<IUnitofWork, UnitOfWork>();
            #endregion


            services.AddDbContext<Context>();
            services.AddIdentity<User, AppRole>(x => {
                x.Password.RequireUppercase = false;
                x.Password.RequireNonAlphanumeric = false;
            }
                ).AddEntityFrameworkStores<Context>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HousingEstateManagementSystem.WepApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HousingEstateManagementSystem.WepApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseSession();
            app.UseAuthentication();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
