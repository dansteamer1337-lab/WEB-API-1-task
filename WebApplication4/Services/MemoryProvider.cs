using WebApplication4.Models;

namespace WebApplication4.Services
{
    public class MemoryProvider
    {
        public List<User> Users { get; set; } = new List<User>();
        public int NextId { get; set; } = 1;

        public MemoryProvider()
        {
            Users.Add(new User { Id = NextId++, UserName = "Admin", Login = "admin" });
            Users.Add(new User { Id = NextId++, UserName = "User1", Login = "user1" });
        }
    }
}