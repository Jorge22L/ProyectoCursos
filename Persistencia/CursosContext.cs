using Dominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class CursosContext : DbContext
    {
        public CursosContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblCursoInstructor>().HasKey(ci => new { ci.InstructorId, ci.CursoId});
            modelBuilder.Entity<tblComentario>().HasKey(ci => new { ci.ComentarioId });
            modelBuilder.Entity<tblCurso>().HasKey(ci => new { ci.CursoId });
            modelBuilder.Entity<tblInstructor>().HasKey(ci => new { ci.InstructorId });
            modelBuilder.Entity<tblPrecio>().HasKey(ci => new { ci.PrecioId });
        }

        public DbSet<tblComentario> tblComentario { get; set; }
        public DbSet<tblCurso> tblCurso { get; set; }
        public DbSet<tblCursoInstructor> tblCursoInstructor { get; set; }
        public DbSet<tblInstructor> tblInstructor { get; set; }
        public DbSet<tblPrecio> tblPrecio { get; set; }

    }
}
