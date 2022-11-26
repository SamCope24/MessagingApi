namespace Api.Repository
{
    public interface IRepository
    {
        List<string> Read();
        void Write(string message);
    }
}