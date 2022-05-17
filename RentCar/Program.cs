using Microsoft.EntityFrameworkCore;
using RentCar.Models;
using RentCar.Models.Interface;
using RentCar.Models.Service;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IRentCar, Vehicule_Type_Service>();
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

app.Run();
