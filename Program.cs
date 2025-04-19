using Microsoft.EntityFrameworkCore;
using ParkingUNAH.Features.Parking.Contracts;
using ParkingUNAH.Features.Parking.Services;
using ParkingUNAH.Features.Usuario.Contracts;
using ParkingUNAH.Features.Usuario.Services;
using ParkingUNAH.Infrastructure.ParkingDb;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ParkingDbContext>(x =>
x.UseSqlServer(builder.Configuration.GetConnectionString("ParkingDb")));

builder.Services.AddScoped<IParkingService, ParkingService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

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
