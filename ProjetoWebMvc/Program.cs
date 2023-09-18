using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using ProjetoWebMvc.Models;
using System.Configuration;
using ProjetoWebMvc.Data;
using ProjetoWebMvc.Services;

var builder = WebApplication.CreateBuilder(args);

string MySqlConnection = builder.Configuration.GetConnectionString("ProjetoWebMvcContext");

builder.Services.AddDbContextPool<ProjetoWebMvcContext>(options =>
                    options.UseMySql(MySqlConnection, ServerVersion.AutoDetect(MySqlConnection)));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<SeedingService>();
builder.Services.AddScoped<SellerService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        var seedingService = services.GetRequiredService<SeedingService>();
        seedingService.Seed();
    }
}
else
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
