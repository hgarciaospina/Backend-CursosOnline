using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Aplicacion.ManejadorError;
using Dominio;
using MediatR;
using Persistencia;

namespace Aplicacion.Cursos
{
    public class ConsultaPorId
    {
        public class CursoUnico : IRequest<Curso>
        {
            public int Id {get; set;}
        }

        public class Manejador : IRequestHandler<CursoUnico, Curso>
        {
            private readonly CursosOnlineContext _context;
            public Manejador(CursosOnlineContext context)
            {
                _context = context;
            }

            public async Task<Curso> Handle(CursoUnico request, CancellationToken cancellationToken)
            {
                Curso? curso = await _context.Curso.FindAsync(request.Id)
                                     ?? throw new ManejadorExcepcion(
                                       HttpStatusCode.NotFound,
                                       new { curso = $"No existe el curso con el Id {request.Id} a ser consultado" });


                return curso;
            }
        }
    }
}