using static System.IO.File;

namespace Api.Repository
{
    public class FileRepository : IRepository
    {
        private readonly string _filePath = "logs.txt";

        public List<string> Read()
        {
            return ReadAllLines(_filePath).ToList();
        }

        public void Write(string message)
        {
            AppendAllText("logs.txt", message + '\n');
        }
    }
}