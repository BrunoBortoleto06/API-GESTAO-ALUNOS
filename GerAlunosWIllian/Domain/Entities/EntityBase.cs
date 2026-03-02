namespace GerAlunosWIllian.Domain.Entities
{
    public abstract class EntityBase
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }

        protected EntityBase()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
        }
    }
}