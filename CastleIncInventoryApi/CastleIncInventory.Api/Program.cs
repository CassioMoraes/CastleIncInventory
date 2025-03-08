using FluentValidation;
using CastleIncInventory.Api.Validators;
using CastleIncInventory.Domain.DataTransfer;
using CastleIncInventory.Domain.Repositories;
using CastleIncInventory.Domain.Services;
using CastleIncInventory.Infrastructure;
using CastleIncInventory.Infrastructure.Repositories;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });


builder.Services.AddCors(options =>
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    })
);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CastleIncInventoryContext>();
builder.Services.AddScoped<IComputerManufacturerRepository,  ComputerManufacturerRepository>();
builder.Services.AddScoped<IComputerRepository, ComputerRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IComputerStatusRepository, ComputerStatusRepository>();
builder.Services.AddScoped<IComputerService, ComputerService>();
builder.Services.AddScoped<IComputerStatusService, ComputerStatusService>();
builder.Services.AddScoped<IValidator<ComputerUpsert>, ComputerValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseCors("CorsPolicy");
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
