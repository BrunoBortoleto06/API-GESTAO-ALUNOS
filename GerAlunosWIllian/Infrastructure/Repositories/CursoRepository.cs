using GerAlunosWIllian.Domain.Entities;
using GerAlunosWIllian.Domain.Interfaces;
using GerAlunosWIllian.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GerAlunosWIllian.Infrastructure.Repositories
{
    public class CursoRepository : ICursoRepository
    {
        private readonly AppDbContext _context;

        public CursoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Curso>> ObterTodosAsync()
        {
            return await _context.Cursos.ToListAsync();
        }

        public async Task<Curso> ObterPorIdAsync(Guid id)
        {
            return await _context.Cursos.FindAsync(id);
        }

        public async Task AdicionarAsync(Curso curso)
        {
            _context.Cursos.Add(curso);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Curso curso)
        {
            _context.Cursos.Update(curso);
            await _context.SaveChangesAsync();
        }

        public async Task DeletarAsync(Guid id)
        {
            var curso = await _context.Cursos.FindAsync(id);
            if (curso != null)
            {
                _context.Cursos.Remove(curso);
                await _context.SaveChangesAsync();
            }
        }
    }
}