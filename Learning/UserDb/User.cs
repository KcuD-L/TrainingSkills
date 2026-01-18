namespace Learning.UserDb
{
    internal class User
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Email { get; set; }
        public string Password { get; set; } = "password";
    }
}
