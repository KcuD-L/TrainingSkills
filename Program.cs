using Learning.Player;
using Learning.UserDb;
using Learning.WorkerAndJobs;

namespace Learning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                User user1 = new User { Name = "Екатерина", Email = "mail@mail.com", Password = "123"};
                User user2 = new User { Name = "Балдун" };

                db.UpdateRange(user1, user2);
                db.SaveChanges();
            }

            using (ApplicationContext db = new ApplicationContext())
            {
                var users = db.Users.ToList();
                Console.WriteLine("Users list:");

                foreach (var user in users)
                {
                    Console.WriteLine($"{user.Id}.{user.Name} - email: {user.Email}     password: {user.Password}");
                }
            }
        }
    }
}