using Aplicacion.ManejadorError;
using MediatR;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Cursos
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
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { curso = "No se encontró el curso"});
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
