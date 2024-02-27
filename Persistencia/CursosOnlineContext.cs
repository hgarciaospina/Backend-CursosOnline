using Dominio;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistencia
{
    public class CursosOnlineContext : IdentityDbContext<Usuario>    {
       
        public CursosOnlineContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Comentario>()
            .HasKey(com => new { com.ComentarioId });

            modelBuilder.Entity<Curso>()
            .HasKey(cur => new { cur.CursoId });

            modelBuilder.Entity<CursoInstructor>()
            .HasKey(cui => new { cui.CursoId, cui.InstructorId });

            modelBuilder.Entity<Instructor>()
            .HasKey(ins => new { ins.InstructorId });
            
            modelBuilder.Entity<Precio>()
            .HasKey(pre => new { pre.PrecioId });

            modelBuilder.Entity<Precio>(entity =>
            {
                entity.Property(pa => pa.PrecioActual).HasColumnType("numeric(12,2)");
                entity.Property(pr => pr.Promocion).HasColumnType("numeric(12,2)");
            });

            modelBuilder.Entity<IdentityUserLogin<string>>().HasNoKey();
            modelBuilder.Entity<IdentityUserRole<string>>().HasNoKey();
            modelBuilder.Entity<IdentityUserToken<string>>().HasNoKey();

        }
        public DbSet<Curso> Curso {get; set;}
        public DbSet<Precio> Precio {get; set;}
        public DbSet<Comentario> Comentario {get; set;}
        public DbSet<Instructor> Instructor {get; set;}
        public DbSet<CursoInstructor> CursoInstructor {get; set;}       
    }
}