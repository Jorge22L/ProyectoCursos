using MediatR;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Curso
{
    public class Eliminar
    {
        public class Ejecuta : IRequest
        {
            public int Id { get; set; }
        }
        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly CursosContext _context;
            public Manejador(CursosContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var curso = await _context.tblCurso.FindAsync(request.Id);
                if(curso == null)
                {
                    throw new Exception("El curso no existe");
                }
                _context.Remove(curso);
                var resultado = await _context.SaveChangesAsync();
                if(resultado > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("No se pudo eliminar el curso");
            }
        }
    }
}
