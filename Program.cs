using Microsoft.EntityFrameworkCore;
using Northwind.DbConnector;
using Northwind.Services;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Northwind.DTOs;
using Northwind.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure AutoMapper and register it with the dependency injection container
var mapperConfig = new MapperConfiguration(config =>
{
    config.CreateMap<Product, ProductDTO>().ReverseMap();
    config.CreateMap<Supplier, SupplierDTO>().ReverseMap();
    // Add more mappings as needed
});
builder.Services.AddScoped<IMapper>(sp => mapperConfig.CreateMapper());


//Might delete
builder.Services.AddCors();
// Line 29: Add CORS services
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:3000") // Allow requests from this origin
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});


// Line 44: Register the database context
builder.Services.AddDbContext<MyAppDbContext>(options => options.UseSqlServer
    (builder.Configuration.GetConnectionString("MyDatabaseConnection")));

// By adding the builder.Services.AddScoped<ProductService>() line, you are instructing the dependency injection container to
// create a new instance of ProductService per HTTP request and make it available for injection wherever it is needed.
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<SupplierService>();

var app = builder.Build();
app.UseCors("AllowOrigin");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
