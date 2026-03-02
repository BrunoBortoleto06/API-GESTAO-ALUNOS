using GerAlunosWIllian.Data;
using GerAlunosWIllian.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GerAlunosWIllian.Controllers
{
    [Route("api/[controller]")] //pega o nome automatico de AlunosController e transforma em api/alunos
    [ApiController]
    public class AlunosController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public AlunosController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> AddAluno(Aluno aluno)
        {
            _appDbContext.Alunos.Add(aluno);
            await _appDbContext.SaveChangesAsync();

            return Ok(aluno);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aluno>>> GetAlunos()
        {
            var alunos = await _appDbContext.Alunos.ToListAsync();
            return Ok(alunos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Aluno>> GetAluno(int id)
        {
            var aluno = await _appDbContext.Alunos.FindAsync(id);

            if (aluno == null)
            {
                return NotFound("Personagem não encontrado!");
            }

            return Ok(aluno);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAluno(int id, [FromBody] Aluno alunoAtualizado)
        {
            var alunoDesatualizado = await _appDbContext.Alunos.FindAsync(id);

            if (alunoDesatualizado == null)
            {
                return NotFound("Personagem não encontrado!");
            }

            _appDbContext.Entry(alunoDesatualizado).CurrentValues.SetValues(alunoAtualizado);

            await _appDbContext.SaveChangesAsync();

            return StatusCode(201, alunoDesatualizado);

        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteAluno(int id)
        {
            var aluno = await _appDbContext.Alunos.FindAsync(id);

            if (aluno == null)
            {
                return NotFound("Personagem não encontrado!");
            }

            _appDbContext.Alunos.Remove(aluno);

            await _appDbContext.SaveChangesAsync();

            return Ok("Personagem deletado com sucesso!");

        }


    }

}
