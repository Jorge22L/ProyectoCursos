using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class tblComentario
    {
        public int ComentarioId { get; set; }
        public string Alumno { get; set; }
        public string Puntaje { get; set; }
        public string ComentarioTexto { get; set; }

        public tblCurso Curso { get; set; }
    }
}
