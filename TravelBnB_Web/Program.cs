using Microsoft.AspNetCore.Authentication.Cookies;
using TravelBnB_Web.Models;
using TravelBnB_Web.Services;
using TravelBnB_Web.Services.IServices;

namespace TravelBnB_Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddAutoMapper(typeof(MappingConfig));
            //apartment
            builder.Services.AddHttpClient<IApartmentService,ApartmentService>();
            builder.Services.AddScoped<IApartmentService, ApartmentService>();
            //roomnumber
            builder.Services.AddHttpClient<IApartmentNumberService, ApartmentNumberService>();
            builder.Services.AddScoped<IApartmentNumberService,ApartmentNumberService>();
            //auth
            builder.Services.AddHttpClient<IAuthService, AuthService>();
            builder.Services.AddScoped<IAuthService, AuthService>();

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie(cookies =>
                    {
                        cookies.Cookie.HttpOnly = true;
                        cookies.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                        cookies.LoginPath = "/Auth/Index";
                        cookies.AccessDeniedPath = "/Auth/AccessDenied";
                        cookies.SlidingExpiration = true; 
                    });
            //httpcontext homepage
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(60);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

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
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}