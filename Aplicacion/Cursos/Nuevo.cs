using Dominio;
using FluentValidation;
using MediatR;
using Persistencia;

namespace Aplicacion.Cursos
{
    public class Nuevo
    {
        public class Ejecuta : IRequest 
        {
            public required string Titulo {get; set;}
            public required string Descripcion {get; set;}
            public required DateTime FechaPublicacion {get; set;}
        }

        public class EjecutaValidacion : AbstractValidator<Ejecuta>
        {
            public EjecutaValidacion()
            {
               RuleFor( cu => cu.Titulo).NotEmpty();
               RuleFor( cu => cu.Descripcion).NotEmpty(); 
               RuleFor( cu => cu.FechaPublicacion).NotEmpty();
            }
        }
        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly CursosOnlineContext _context;
            public Manejador(CursosOnlineContext context)
            {
              _context = context;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var curso = new Curso 
                { 
                    Titulo = request.Titulo, 
                    Descripcion = request.Descripcion, 
                    FechaPublicacion = request.FechaPublicacion 
                };

                _context.Curso.Add(curso);
                var valor = await _context.SaveChangesAsync();
                if(valor>0) 
                {
                    return Unit.Value;
                }

                throw new Exception("No se pudo insertar el curso");
            }
        }
    }
}