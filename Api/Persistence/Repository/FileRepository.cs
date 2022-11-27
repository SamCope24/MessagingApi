using static System.IO.File;

namespace Api.Persistence.Repository
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

        public void Clean()
        {
            Create(_filePath).Close();
        }
    }
}