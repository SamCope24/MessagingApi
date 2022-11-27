namespace Api.Persistence.Repository
{
    public interface IRepository
    {
        List<string> Read();
        void Write(string message);
    }
}