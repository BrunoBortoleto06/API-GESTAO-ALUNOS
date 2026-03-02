using GerAlunosWIllian.Application.DTOs;
using GerAlunosWIllian.Domain.Entities;

namespace GerAlunosWIllian.Application.Services
{
    public interface ICursoService
    {
        Task<IEnumerable<Curso>> ObterTodosAsync();
        Task<Curso> ObterPorIdAsync(Guid id);
        Task AdicionarAsync(CreateCursoDTO cursoDto);
        Task<bool> AtualizarAsync(Guid id, Curso cursoAtualizado);
        Task<bool> DeletarAsync(Guid id);
    }
}