using Api.Persistence.EntityFramework;
using Api.Persistence.EntityFramework.Entities;

namespace Api.Persistence.Repository
{
    public class PostgresRepository : IRepository
    {
        private readonly MessagingDbContext _context;

        public PostgresRepository(MessagingDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public List<string> Read()
        {
            return _context.Messages.Select(message => message.MessageText).ToList();
        }

        public void Write(string message)
        {
            _context.Messages.Add(new Message
            {
                MessageText = message
            });

            _context.SaveChanges();
        }

        public void Clean()
        {
            _context.Messages.RemoveRange(_context.Messages);
            _context.SaveChanges();
        }
    }
}