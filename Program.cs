using Learning.WorkerAndJobs;

namespace Learning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Worker worker = WorkerFactory.Create();
        }
    }
}