using PizzaApp.Data;
using Microsoft.EntityFrameworkCore;
using PizzaApp.DataAccess.Repos.Contracts;
using PizzaApp.DataAccess.Repos;
using PizzaApp.BusinessLogic.Services;
using PizzaApp.BusinessLogic.Services.Contracts;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<LocalDbContext>(
options =>
    {
        options.UseSqlServer(builder.Configuration["ConnectionStrings:ConnectionString"]);
        options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        options.LogTo(Console.WriteLine, LogLevel.Information);

        if (!builder.Environment.IsProduction())
        {
            options.EnableSensitiveDataLogging()
            .EnableDetailedErrors();
        }
    });

builder.Services
    .AddCors(options =>
    {
        options.AddPolicy(name: "AllowAll", builder =>
        {
            builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        });
    });

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IProductsRepository, ProductsRepository>();
builder.Services.AddScoped<IProductsService, ProductsService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors("AllowAll");

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
