using Flightly.Data;
using Flightly.Services.Interfaces;
using Flightly.Services;
using Microsoft.EntityFrameworkCore;
using Flightly.Repositories;
using Flightly.Repositories.Interfaces;
using Flightly.Helpers.Interfaces;
using Flightly.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<FlightDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("Database")
    )
);

// Register repositories
builder.Services.AddScoped<IFlightsRepository, FlightsRepository>();

// Register services
builder.Services.AddScoped<IFlightsService, FlightsService>();
builder.Services.AddScoped<IHelpers, Helpers>();

// Register controllers
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//SWAGGER
app.UseSwagger(c =>
{
    // Change the path to include /api
    c.RouteTemplate = "/api/swagger/{documentName}/swagger.json";
});

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/api/swagger/v1/swagger.json", "Flightly API v1");
    c.RoutePrefix = "api";
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
