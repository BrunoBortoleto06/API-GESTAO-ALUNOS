namespace GerAlunosWIllian.Domain.Entities
{
    public class Curso : EntityBase
    {
        public required string Name { get; set; }
        public ICollection<Aluno> Alunos { get; set; } = new List<Aluno>();
    }
}