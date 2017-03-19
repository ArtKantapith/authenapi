using System.Collections.Generic;

namespace AuthenApi.Models
{
    public interface IUserRepository
    {
        void Add(User user);
        IEnumerable<User> GetAll();
        User Find(int key);
        User Find(string name, string password);
        User Remove(int key);
        void Update(User user);
    }
}