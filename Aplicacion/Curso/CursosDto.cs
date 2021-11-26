using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Curso
{
    public class CursosDto
    {
        public Guid CursoId { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime? FechaPublicacion { get; set; }
        public byte[] FotoPortada { get; set; }

        public ICollection<InstructoresDTO> Instructores { get; set; }
    }
}
