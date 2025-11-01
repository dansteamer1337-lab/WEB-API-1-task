using WebApplication4.Models;
using WebApplication4.Repositories.Interfaces;
using WebApplication4.Services;

namespace WebApplication4.Repositories
{
    public class UsersRepositoryInMemory : IUserRepositoryInMemory
    {
        private readonly MemoryProvider _memoryProvider;

        public UsersRepositoryInMemory(MemoryProvider memoryProvider)
        {
            _memoryProvider = memoryProvider;
        }

        public List<User> GetData()
        {
            return _memoryProvider.Users;
        }

        public User? GetData(int id)
        {
            return _memoryProvider.Users.FirstOrDefault(u => u.Id == id);
        }

        public void Add(User user)
        {
            user.Id = _memoryProvider.NextId++;
            _memoryProvider.Users.Add(user);
        }

        public void Delete(int id)
        {
            var user = GetData(id);
            if (user != null)
            {
                _memoryProvider.Users.Remove(user);
            }
            else
            {
                throw new ArgumentException($"User with id {id} not found");
            }
        }

        public void Edit(User user)
        {
            var existingUser = GetData(user.Id);
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