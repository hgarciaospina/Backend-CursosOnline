using Aplicacion.Cursos;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;
using WebAPI.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Configuraciónn de validaciones
builder.Services.AddControllers().AddFluentValidation( cfg => cfg.RegisterValidatorsFromAssemblyContaining<Nuevo>());

//Configuración cadena de conexión
builder.Services.AddDbContext<CursosOnlineContext>(opt => {
  opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
}); 
   
builder.Services.AddMediatR(typeof(Consulta.Manejador).Assembly);   
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

//Configuración manejo de errores
app.UseMiddleware<ManejadorErrorMiddleware>();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
