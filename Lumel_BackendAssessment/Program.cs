using Lumel_BackendAssessment.Application.Interfaces;
using Lumel_BackendAssessment.Application.Services;
using Lumel_BackendAssessment.Infrastructure.Csv;
using Lumel_BackendAssessment.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<SalesCsvImporter>();

builder.Services.AddScoped<IOrderRepository, RavenOrderRepository>();
builder.Services.AddScoped<IProductRepository, RavenProductRepository>();
builder.Services.AddScoped<ICustomerRepository, RavenCustomerRepository>();

builder.Services.AddScoped<DataRefreshService>();
builder.Services.AddScoped<RevenueCalculationService>();

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
