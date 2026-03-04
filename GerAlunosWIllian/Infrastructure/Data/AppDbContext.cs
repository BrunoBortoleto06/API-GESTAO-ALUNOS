using GerAlunosWIllian.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GerAlunosWIllian.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Curso> Cursos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Aluno>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.LastName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(200);
                entity.Property(e => e.CursoId).IsRequired();

                entity.HasOne(e => e.Curso)
                      .WithMany(c => c.Alunos)
                      .HasForeignKey(e => e.CursoId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Curso>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
            });
        }
    }
}
