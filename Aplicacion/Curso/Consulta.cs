using Aplicacion.Curso;
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

namespace Aplicacion.Cursos
{
    public class Consulta
    {
        public class ListaCursos : IRequest<List<CursosDto>> { }

        public class Manejador : IRequestHandler<ListaCursos, List<CursosDto>>
        {

            private readonly CursosContext _context;
            public Manejador(CursosContext context)
            {
                _context = context;
            }

            public async Task<List<CursosDto>> Handle(ListaCursos request, CancellationToken cancellationToken)
            {
                var cursos = await _context.tblCurso.Include(x => x.InstructoresLink).ThenInclude(y => y.Instructor).ToListAsync();
                return cursos;
            }

        }
    }
}

