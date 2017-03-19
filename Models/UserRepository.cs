using System.Collections.Generic;

namespace AuthenApi.Models
{
    public class UserRepository : IUserRepository
    {
        private readonly AuthenContext _context;

        public UserRepository(AuthenContext context)
        {
            _context = context;
        }

        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public User Find(int key)
        {
            return _context.Users.Find(key);
        }

        public User Find(string name, string password)
        {
            //TODO FirstOrDefault is not implemented yet
            foreach(User user in _context.Users) {
                if(user.Name == name && user.Password == password) {
                    return user;
                }
            }
            return null;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        public User Remove(int key)
        {
            User user = _context.Users.Find(key);
            _context.Users.Remove(user);
            _context.SaveChanges();
            return user;
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }
    }
}