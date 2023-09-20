using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Localization;
using ProjetoWebMvc.Models;
using ProjetoWebMvc.Data;
using ProjetoWebMvc.Services;
using System.Globalization;
using System.Configuration;


var builder = WebApplication.CreateBuilder(args);

string MySqlConnection = builder.Configuration.GetConnectionString("ProjetoWebMvcContext");

builder.Services.AddDbContextPool<ProjetoWebMvcContext>(options =>
                    options.UseMySql(MySqlConnection, ServerVersion.AutoDetect(MySqlConnection)));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<SeedingService>();
builder.Services.AddScoped<SellerService>();
builder.Services.AddScoped<DepartmentService>();
builder.Services.AddScoped<SalesRecordService>();

var app = builder.Build();

// definindo local padrão do USA
var enUS = new CultureInfo("en-US");
var localizationOptions = new RequestLocalizationOptions 
{ 
    DefaultRequestCulture = new RequestCulture("en-US") ,
    SupportedCultures = new List<CultureInfo> { enUS },
    SupportedUICultures = new List<CultureInfo> { enUS }
};

app.UseRequestLocalization(localizationOptions);


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
