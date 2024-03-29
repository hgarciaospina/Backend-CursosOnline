
using Aplicacion.ManejadorError;
using Dominio;
using MediatR;
using Persistencia;
using System.Net;
namespace Aplicacion.Cursos
{
    public class Eliminar
    {
        public class Ejecuta : IRequest
        {
            public int Id {get; set;}
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
                Curso? curso = await _context.Curso.FindAsync(request.Id)
                                      ?? throw new ManejadorExcepcion(
                                        HttpStatusCode.NotFound, 
                                        new {curso = $"No existe el curso con el Id {request.Id} a eliminar"});
                _context.Remove(curso);
                
                var resultado = await _context.SaveChangesAsync();
                
                if(resultado>0)
                {
                    return Unit.Value;
                }

                throw new Exception("No se pudo grabar los cambios al eliminar");
            }
        }
    }
}