using Microsoft.EntityFrameworkCore;
using P1_AP1_VictorManuel.Components;
using P1_AP1_VictorManuel.Dal;
using P1_AP1_VictorManuel.Services;

namespace P1_AP1_VictorManuel;

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();


            var ConStr = builder.Configuration.GetConnectionString("SqlConStr");

            builder.Services.AddDbContextFactory<Contexto>(o => o.UseSqlite(ConStr));

            builder.Services.AddScoped<RegistroServices>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            
            app.UseAntiforgery();
            

            app.MapStaticAssets();
            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }

