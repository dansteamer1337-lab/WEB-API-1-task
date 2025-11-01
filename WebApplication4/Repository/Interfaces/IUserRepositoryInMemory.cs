using WebApplication4.Models;

namespace WebApplication4.Repositories.Interfaces
{
    public interface IUserRepositoryInMemory
    {
        List<User> GetData();
        User? GetData(int id);
        void Add(User user);
        void Delete(int id);
        void Edit(User user);
    }
}