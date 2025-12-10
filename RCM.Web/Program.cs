using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using RCM.BLL.Services;
using RCM.DAL.Context;
using RCM.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")));

builder.Services.AddScoped<IRetailerRepository, RetailerRepository>();
builder.Services.AddScoped<IRetailerService, RetailerService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // This serves files from wwwroot

app.UseRouting();



app.UseAuthorization();

// Map controllers
app.MapControllers();

// Swagger
app.UseSwagger();
app.UseSwaggerUI();


app.Run();