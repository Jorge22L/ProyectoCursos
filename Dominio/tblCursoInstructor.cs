using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class tblCursoInstructor
    {
        public int CursoId { get; set; }
        public tblCurso Curso { get; set; }
        public int InstructorId { get; set; }
    }
}
