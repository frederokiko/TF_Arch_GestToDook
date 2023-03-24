using Microsoft.Extensions.Configuration;
using TF_Arch_GestToDo.Dal.Repositories;
using TF_Arch_GestToDo.Dal.Services;
using Tools.Ado;


var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

IConfiguration configuration = builder.Configuration;

IServiceCollection services = builder.Services;
services.AddControllersWithViews();
services.AddScoped(sp => new Connection(configuration.GetConnectionString("Database")));
services.AddScoped<IToDoRepository, ToDoRepository>();
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
