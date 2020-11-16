using Dock.UI.Site.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Dock.UI.AppModelo
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddTransient<IPedidoRepository, PedidoRepository>();

            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.AreaViewLocationFormats.Clear();
                options.AreaViewLocationFormats.Add("/Modules/{2}/Views/{1}/{0}.cshtml");
                options.AreaViewLocationFormats.Add("/Modules/{2}/Views/Shared/{0}.cshtml");
                options.AreaViewLocationFormats.Add("/Views/Shared/{0}.cshtml");
            });

            services.AddDbContext<MyDbContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("MyDbContext")));


            services.AddMvc(options => options.EnableEndpointRouting = false).SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Latest);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "MyArea",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });


            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");

            //    routes.MapRoute(name: "areas", template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
            //});
        }
    }
}
