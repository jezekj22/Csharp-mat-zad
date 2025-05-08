// Úprava Program.cs
using System;
using Microsoft.EntityFrameworkCore;
using NotesAppAspNet.Data; // Pøidej tento using podle toho, kde budeš mít AppDbContext

var builder = WebApplication.CreateBuilder(args);

// Naètení connection stringu z appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Registrace DbContextu
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");