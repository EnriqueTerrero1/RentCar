using Microsoft.EntityFrameworkCore;
using RentCar.Models;
using RentCar.Models.Interface;
using RentCar.Models.Service;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IRentCar<Vehicule_Type>, RentCarService<Vehicule_Type>>();
builder.Services.AddScoped<IRentCar<VehiculeModel>, RentCarService<VehiculeModel>>();
builder.Services.AddScoped<IRentCar<Vehicule>, RentCarService<Vehicule>>();
builder.Services.AddScoped<IRentCar<Brand>, RentCarService<Brand>>();
builder.Services.AddScoped<IRentCar<Fuel_Type>, RentCarService<Fuel_Type>>();
builder.Services.AddScoped<IRentCar<Client>,RentCarService<Client>>();
builder.Services.AddScoped <IRentCar<RentAndReturn>, RentCarService<RentAndReturn>>();
builder.Services.AddScoped<IRentCar<Employee>, RentCarService<Employee>>();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<RentCarDBcontext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Database")));


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
    pattern: "{controller=Vehicule_Type}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Vehicule_Model}/{action=Create}/{string?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Vehicule_Model}/{action=Create}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Vehicule}/{action=Update}/{description?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Vehicule}/{action=Update}/{id?}/{description?}");




app.Run();
