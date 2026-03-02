using GerAlunosWIllian.Models;
using Microsoft.EntityFrameworkCore;

namespace GerAlunosWIllian.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }
        
        public DbSet<Aluno> Alunos { get; set; }

    }
}
