using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class tblPrecio
    {
        public Guid PrecioId { get; set; }
        [Column(TypeName ="decimal(18,4)")]
        public decimal PrecioActual { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Promocion { get; set; }
        public Guid CursoId { get; set; }
        public tblCurso Curso { get; set; }
    }
}
