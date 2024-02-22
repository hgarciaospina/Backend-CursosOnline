using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio
{
    public class CursoInstructor
    {
        public int CursoId {get; set;}
        public int InstructorId {get; set;}
         public required Curso Curso {get; set;}
        public required Instructor Instructor {get; set;}
    }
}