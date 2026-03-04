namespace GerAlunosWIllian.Domain.Entities
{
    public class Aluno : EntityBase
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required Guid CursoId { get; set; }
        public Curso? Curso { get; set; }
    }
}