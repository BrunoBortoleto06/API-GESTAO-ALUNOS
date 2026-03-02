using GerAlunosWIllian.Domain.Entities;

namespace GerAlunosWIllian.Domain.Interfaces
{
    public interface ICursoRepository
    {
        Task<IEnumerable<Curso>> ObterTodosAsync();
        Task<Curso> ObterPorIdAsync(Guid id);
        Task AdicionarAsync(Curso curso);
        Task AtualizarAsync(Curso curso);
        Task DeletarAsync(Guid id);
    }
}