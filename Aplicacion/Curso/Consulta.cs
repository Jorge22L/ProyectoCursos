using Dominio;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Curso
{
    public class Consulta
    {
        public class ListaCursos : IRequest<List<tblCurso>> { }

        public class Manejador : IRequestHandler<ListaCursos, List<tblCurso>>
        {
            private readonly CursosContext _context;

            public Manejador(CursosContext context)
            {
                _context = context;
            }
            public async Task<List<tblCurso>> Handle(ListaCursos request, CancellationToken cancellationToken)
            {
                var cursos = await _context.tblCurso.ToListAsync();
                return cursos;
            }
        }
    }
}
