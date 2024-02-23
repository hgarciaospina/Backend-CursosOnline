using System.Net;
using Aplicacion.ManejadorError;
using FluentValidation;
using MediatR;
using Persistencia;

namespace Aplicacion.Cursos
{
    public class Editar
    {
        public class Ejecuta : IRequest 
        {
          public int CursoId {get; set;}
          public required string Titulo {get; set;}
          public required string Descripcion {get; set;}
          public DateTime FechaPublicacion {get; set;}
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
            
               var curso = await _context.Curso.FindAsync(request.CursoId);
               
               if(curso == null)
               {
                  throw new ManejadorExcepcion(
                            HttpStatusCode.NotFound, 
                            new {curso = $"No existe el curso con el Id {request.CursoId} a ser modificado"});

               }

                 curso.Titulo = request.Titulo;
                 curso.Descripcion = request.Descripcion;
                 curso.FechaPublicacion = request.FechaPublicacion;

                var resultado = await _context.SaveChangesAsync();

                if(resultado>0) return Unit.Value;

                throw new Exception($"No se guardaron los cambios en el curso de Id: {request.CursoId}");       
                
            }
        }
    }
}