using AutoMapper;
using CivilManagement.Business.Abstract;
using CivilManagement.Business.Concrete;
using CivilManagement.DataAccess.Abstract;
using CivilManagement.DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Smidge;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Smidge.Options;
using Smidge.Cache;
using CivilManagement.UI.CustomExtention;

namespace CivilManagement.UI
{
    public class Startup
    {
        public IConfiguration _Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            _Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSmidge(_Configuration.GetSection("smidge"));
            services.AddAutoMapper(typeof(Startup));

            services.AddScoped<IReturnDal, EfReturnDal>();
            services.AddScoped<IItemBarcodeDal, EfItemBarcode>();
            services.AddScoped<IUserDal, EfUserDal>();
            services.AddScoped<IReturnInvoiceControlDal, EfReturnInvoiceControlDal>();

            services.AddScoped<IReturnService, ReturnService>();
            services.AddScoped<IItemBarcodeService, ItemBarcodeService>();
            services.AddScoped<IReturnInvoiceControlService, ReturnInvoiceControlService>();

            //services.AddDbContext<CivilContext>(options =>
            //options.UseSqlServer(_Configuration.GetConnectionString("DefaultConnection")));
            services.AddControllersWithViews();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSmidgeCustom();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=return}/{action=index}/{id?}");
            });
        }
    }
}