using Aplicacion.Curso;
using AutoMapper;
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
        public class ListaCursos : IRequest<List<CursoDto>> { }

        public class Manejador : IRequestHandler<ListaCursos, List<CursoDto>>
        {

            private readonly CursosContext _context;
            private readonly IMapper _mapper;

            public Manejador(CursosContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<CursoDto>> Handle(ListaCursos request, CancellationToken cancellationToken)
            {
                var cursos = await _context.tblCurso
                    .Include(x => x.InstructoresLink)
                    .ThenInclude(y => y.Instructor)
                    .ToListAsync();

                var cursosDto = _mapper.Map<List<tblCurso>, List<CursoDto>>(cursos);
                return cursosDto;
            }

        }
    }
}

