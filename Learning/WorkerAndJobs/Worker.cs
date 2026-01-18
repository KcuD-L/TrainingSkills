namespace Learning.WorkerAndJobs
{
    internal class Worker : Human
    {
        public int? Salary { get; set; }
        public string? JobTitle { get; set; }
        public Worker(string name, int salary, string job)
        {
            Name = name;
            Salary = salary;
            JobTitle = job;
        }

        public override string ToString() => $"Работник: {Name} Зарплата: {Salary} Должность: {JobTitle}";
    }
}
