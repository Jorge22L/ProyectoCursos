using Dominio;
using MediatR;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Cursos
{
    public class ConsultaId
    {
        public class CursoUnico : IRequest<tblCurso>
        {
            public int Id { get; set; }
        }

        public class Manejador : IRequestHandler<CursoUnico, tblCurso>
        {
            private readonly CursosContext _context;
            public Manejador(CursosContext context)
            {
                _context = context;
            }
            public async Task<tblCurso> Handle(CursoUnico request, CancellationToken cancellationToken)
            {
                var curso = await _context.tblCurso.FindAsync(request.Id);
                return curso;
            }
        }
    }
}
