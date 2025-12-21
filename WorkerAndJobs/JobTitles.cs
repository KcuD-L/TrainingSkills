namespace Learning.WorkerAndJobs
{
    static internal class JobTitles
    {
        private static readonly Dictionary<int, string> Titles = new()
        {
            [0] = "owner",
            [1] = "cleaner",
            [2] = "manager"
        };

        static public string? Get(int id) => Titles[id];

        static public int GetLenght() => Titles.Count;

        static public void ViewAll()
        {
            foreach (KeyValuePair<int, string> pair in Titles)
            {
                Console.WriteLine($"Id: {pair.Key}  title: {pair.Value}");
            }
        }
    }
}
