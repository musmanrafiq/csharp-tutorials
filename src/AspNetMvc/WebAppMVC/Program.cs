using Microsoft.Extensions.Options;
using WebAppMVC.IOptionsModel;

namespace WebAppMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddOptions<EmailSetting>()
                .BindConfiguration("EmailSetting")
                .ValidateDataAnnotations()
                .ValidateOnStart();

            //builder.Services.Configure<EmailSetting>(builder.Configuration.GetSection("EmailSetting"));

            builder.Services.AddSingleton(es => es.GetRequiredService<IOptions<EmailSetting>>().Value);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
