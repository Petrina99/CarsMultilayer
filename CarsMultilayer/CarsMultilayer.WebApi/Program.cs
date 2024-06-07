using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using CarsMultilayer.CarService;
using CarsMultilayer.CarsRepository;
using CarsMultilayer.Model;
using CarsMultilayer.WebApi.Models;

var builder = WebApplication.CreateBuilder(args);
var containerBuilder = new ContainerBuilder();
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterModule<CarRepositoryModule>();
    containerBuilder.RegisterModule<CarServiceModule>();
});

var container = containerBuilder.Build();

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(CarMappingProfile));
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
