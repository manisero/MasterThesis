namespace Sample.Domain.Entities
{
    public class Comment : IEntity
    {
        public string Author { get; set; }

        public string Content { get; set; }
    }
}
