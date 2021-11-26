using Dominio;
using FluentValidation;
using MediatR;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Cursos
{
    public class Nuevo
    {
        public class Ejecuta : IRequest
        {
            public string Titulo { get; set; }
            public string Descripcion { get; set; }
            public DateTime? FechaPublicacion { get; set; }

            public List<Guid> ListaInstructor { get; set; }
        }

        public class EjecutaValidacion : AbstractValidator<Ejecuta>
        {
            public EjecutaValidacion()
            {
                RuleFor(x => x.Titulo).NotEmpty();
                RuleFor(x => x.Descripcion).NotEmpty();
                RuleFor(x => x.FechaPublicacion).NotEmpty();
            }
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
                Guid _cursoId = Guid.NewGuid();
                Debug.WriteLine(_cursoId);
                var curso = new tblCurso
                {
                    CursoId = _cursoId,
                    Titulo = request.Titulo,
                    Descripcion = request.Descripcion,
                    FechaPublicacion = request.FechaPublicacion
                };

                _context.tblCurso.Add(curso);

                //Agregando en tabla CursoInstructor
                if(request.ListaInstructor != null)
                {
                    foreach (var id in request.ListaInstructor)
                    {
                        var cursoInstructor = new tblCursoInstructor
                        {
                            CursoId = _cursoId,
                            InstructorId = id
                        };

                        _context.tblCursoInstructor.Add(cursoInstructor);
                    }
                }
                var valor = await _context.SaveChangesAsync();
                if(valor > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("No se pudo insertar el curso");
            }
        }
    }

}
