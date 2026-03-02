using GerAlunosWIllian.Application.DTOs;
using GerAlunosWIllian.Domain.Entities;
using GerAlunosWIllian.Domain.Interfaces;

namespace GerAlunosWIllian.Application.Services
{
    public class CursoService : ICursoService
    {
        private readonly ICursoRepository _cursoRepository;

        public CursoService(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }

        public async Task<IEnumerable<Curso>> ObterTodosAsync()
        {
            return await _cursoRepository.ObterTodosAsync();
        }

        public async Task<Curso> ObterPorIdAsync(Guid id)
        {
            return await _cursoRepository.ObterPorIdAsync(id);
        }

        public async Task AdicionarAsync(CreateCursoDTO cursoDto)
        {
            if (string.IsNullOrWhiteSpace(cursoDto.Name))
            {
                throw new Exception("nome do curso é obrigatório.");
            }

            var novoCurso = new Curso
            {
                Name = cursoDto.Name,
            };

            await _cursoRepository.AdicionarAsync(novoCurso);
        }

        public async Task<bool> AtualizarAsync(Guid id, Curso cursoAtualizado)
        {
            var cursoDesatualizado = await _cursoRepository.ObterPorIdAsync(id);

            if (cursoDesatualizado == null)
            {
                return false;
            }

            cursoDesatualizado.Name = cursoAtualizado.Name;


            await _cursoRepository.AtualizarAsync(cursoDesatualizado);
            return true;
        }

        public async Task<bool> DeletarAsync(Guid id)
        {
            var cursoExiste = await _cursoRepository.ObterPorIdAsync(id);

            if (cursoExiste == null)
            {
                return false;
            }

            await _cursoRepository.DeletarAsync(id);
            return true;
        }
    }
}