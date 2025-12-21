using System;

namespace Learning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите имя работника");
            string name = Input.CheckString();
            Console.WriteLine("Введите зарплату работника");
            int salary = Input.CheckInt();
            Console.WriteLine("Введите должность работника");
            JobTitles.ViewAll();
            string? title = JobTitles.Get(Input.CheckBoundRetry(Input.CheckInt(), 0, JobTitles.GetLenght() - 1));
            
            Worker worker = new Worker(name, salary, title);

            Console.Clear();
            Console.WriteLine("Работник создан!");

            Console.WriteLine(worker.ToString());
        }
    }
}