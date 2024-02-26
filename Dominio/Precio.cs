using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio
{
    public class Precio
    {
        public Guid PrecioId {get; set;}
        public decimal PrecioActual {get; set;}
        public decimal Promocion {get; set;}
        public Guid CursoId {get; set;}
        public required Curso Curso {get; set;}
    }
}