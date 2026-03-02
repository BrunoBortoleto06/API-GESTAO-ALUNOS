using GerAlunosWIllian.Application.DTOs;
using GerAlunosWIllian.Application.Services;
using GerAlunosWIllian.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GerAlunosWIllian.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursosController : ControllerBase
    {
        private readonly ICursoService _cursoService;

        public CursosController(ICursoService cursoService)
        {
            _cursoService = cursoService;
        }

        [HttpPost]
        public async Task<IActionResult> AddCurso([FromBody] CreateCursoDTO cursoDto)
        {
            try
            {
                await _cursoService.AdicionarAsync(cursoDto);
                return StatusCode(201, cursoDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Curso>>> GetCursos()
        {
            var cursos = await _cursoService.ObterTodosAsync();
            return Ok(cursos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Curso>> GetAluno(Guid id)
        {
            var curso = await _cursoService.ObterPorIdAsync(id);

            if (curso == null) return NotFound("Aluno não encontrado!");

            return Ok(curso);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCurso(Guid id, [FromBody] Curso cursoAtualizado)
        {
            var sucesso = await _cursoService.AtualizarAsync(id, cursoAtualizado);

            if (!sucesso) return NotFound("Aluno não encontrado!");

            return StatusCode(201, cursoAtualizado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCurso(Guid id)
        {
            var sucesso = await _cursoService.DeletarAsync(id);

            if (!sucesso) return NotFound("Aluno não encontrado!");

            return Ok("Aluno deletado com sucesso!");
        }
    }
}