using Microsoft.Extensions.Configuration;
using TO_DO_List_Backend.Application.Contracts;
using TO_DO_List_Backend.Application.Services;
using TO_DO_List_Backend.Domain.InfraestructureContracts;
using TO_DO_List_Backend.Extencions;
using TO_DO_List_Backend.Persistence.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IToDoListRepository, ToDoListRepository>();
builder.Services.AddScoped<ITaskApplication, TaskApplication>();
builder.Services.AddDbContextExtencion();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
