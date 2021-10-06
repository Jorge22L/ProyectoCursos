using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class tblCurso
    {
        public Guid CursoId { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime? FechaPublicacion { get; set; }
        public byte[] FotoPortada { get; set; }
        public tblPrecio PrecioPromocion { get; set; }

        public ICollection<tblComentario> ListaComentarios { get; set; }
        public ICollection<tblCursoInstructor> ListaInstructo { get; set; }
    }
}
