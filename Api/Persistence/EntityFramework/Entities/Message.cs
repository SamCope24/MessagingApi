namespace Api.Persistence.EntityFramework.Entities
{
    public class Message
    {
        public int MessageId { get; set; }
        public string MessageText { get; set; } = null!;
    }
}