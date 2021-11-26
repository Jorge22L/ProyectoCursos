using Aplicacion.Curso;
using AutoMapper;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion
{
    public class MappingProfile : Profile
    {
        //CLASE QUE PERMITE MAPEAR Y TRANSFORMAR LOS ATRIBUTOS EN CLASES DTO
        // PARA COMBINARLOS Y POSTERIORMENTE MOSTRARLOS DE MANERA PARECIDA A UNA VISTA SQL
        public MappingProfile()
        {
            CreateMap<tblCurso, CursoDto>()
                .ForMember(x => x.Instructores, y => y.MapFrom(z => z.InstructoresLink.Select(a => a.Instructor).ToList()));
            CreateMap<tblCursoInstructor, CursoInstructorDto>();
            CreateMap<tblInstructor, InstructorDto>();
        }
    }
}
