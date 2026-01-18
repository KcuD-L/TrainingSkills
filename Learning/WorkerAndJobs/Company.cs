using System.Text;
namespace Learning.WorkerAndJobs
{
    internal class Company
    {
        public string Name { get; }
        public string Description { get; }
        public int Id { get; set; }
        public List<Worker> Workers { get; } = new();

        public Company(string name, string description, Worker worker)
        {
            Name = name;
            Description = description;
            Workers.Add(worker);
        }

        public string GetInfo()
        {
            var info = new StringBuilder();
            info.AppendLine(Name);
            info.AppendLine(Description);
            foreach (var worker in Workers)
            {
                info.AppendLine($"Работник: {worker.Name} получает: {worker.Salary} и является: {worker.JobTitle}");
            }
            return info.ToString();
        }
    }
}
