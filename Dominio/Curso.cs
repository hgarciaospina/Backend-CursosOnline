using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio
{
    public class Curso
    {
        public int CursoId {get; set;}
        public required string Titulo {get; set;}
        public required string Descripcion {get; set;}
        public required DateTime FechaPublicacion {get; set;}
        public byte[]? FotoPortada {get; set;}
        public  Precio? Precio {get; set;}  
        public ICollection<Comentario>? Comentarios {get; set;}
        public ICollection<CursoInstructor>? InstructoresLink {get; set;}
    }
}