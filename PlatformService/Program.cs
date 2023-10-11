using Microsoft.EntityFrameworkCore;
using PlatformService.Data;
using PlatformService.Services;
using System.Runtime.CompilerServices;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Environment and configuration before build
IWebHostEnvironment env = builder.Environment;
IConfiguration config = builder.Configuration;

// Add services to the container.
builder.Services.ConfigureServices(env, config);

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

PrepDB.PrepPopulation(app, env.IsProduction());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();