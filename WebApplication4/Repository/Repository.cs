using WebApplication4.Models;

namespace WebApplication4.Repository
{
    public static class Repository
    {
        private static List<User> _users = new List<User>();
        private static int _nextId = 1;

        static Repository()
        {
            // Добавим несколько тестовых пользователей
            _users.Add(new User { Id = _nextId++, UserName = "Admin", Login = "admin" });
            _users.Add(new User { Id = _nextId++, UserName = "User1", Login = "user1" });
        }

        public static List<User> GetUsers()
        {
            return _users;
        }

        public static User? GetUserById(int id)
        {
            return _users.FirstOrDefault(u => u.Id == id);
        }

        public static void AddUser(User user)
        {
            user.Id = _nextId++;
            _users.Add(user);
        }

        public static void DeleteUser(int id)
        {
            var user = GetUserById(id);
            if (user != null)
            {
                _users.Remove(user);
            }
            else
            {
                throw new ArgumentException($"User with id {id} not found");
            }
        }

        public static void UpdateUser(User user)
        {
            var existingUser = GetUserById(user.Id);
            if (existingUser != null)
            {
                existingUser.UserName = user.UserName;
                existingUser.Login = user.Login;
            }
            else
            {
                throw new ArgumentException($"User with id {user.Id} not found");
            }
        }
    }
}