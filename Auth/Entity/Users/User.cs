namespace Auth.Entity.Users
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public RoleEnum Role { get; set; } = 0;
    }
}
