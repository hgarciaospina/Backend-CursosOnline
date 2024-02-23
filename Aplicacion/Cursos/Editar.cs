using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
                var curso = await _context.Curso.FindAsync(request.CursoId) ?? throw new Exception("El curso no existe");

                curso.Titulo = request.Titulo ?? curso.Titulo;
                curso.Descripcion = request.Descripcion ?? curso.Descripcion;
                curso.FechaPublicacion = request.FechaPublicacion;

                var resultado = await _context.SaveChangesAsync();

                if(resultado>0) return Unit.Value;

                throw new Exception("No se guardaron los cambios en el curso");       
                
            }
        }
    }
}