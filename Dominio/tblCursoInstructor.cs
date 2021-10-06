using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class tblCursoInstructor
    {
        public Guid CursoId { get; set; }
        public tblCurso Curso { get; set; }
        public Guid InstructorId { get; set; }

        public tblInstructor Instructor { get; set; }
    }
}
