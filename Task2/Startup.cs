using Microsoft.EntityFrameworkCore;
using Task2.DB;

namespace Task2 {

    public class Startup {
        
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services) {
            services.AddControllersWithViews()
                .AddDataAnnotationsLocalization(options => {
                    options.DataAnnotationLocalizerProvider = (type, factory) =>
                        factory.Create(typeof(Startup));
                });
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            } else {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Registration}/{action=Index}/{id?}");
                
                endpoints.MapControllerRoute(
                    name: "participants",
                    pattern: "Registration/AllParticipants",
                    defaults: new { controller = "Registration", action = "AllParticipants" });
            });
        }
    }
}