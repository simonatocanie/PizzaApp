
using PizzaApp.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<PizzaDbContext>(
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
