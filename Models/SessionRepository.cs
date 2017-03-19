using System;

namespace AuthenApi.Models
{
    public class SessionRepository : ISessionRepository
    {
        private readonly AuthenContext _context;

        public SessionRepository(AuthenContext context)
        {
            _context = context;
        }
        public Session Add(int userid)
        {
            if(_context.Users.Find(userid) == null) {
                return null;
            }
            Session session = new Session();
            session.UserID = userid;
            _context.Sessions.Add(session);
            _context.SaveChanges();
            return session;
        }

        public Session Find(int key)
        {
            return _context.Sessions.Find(key);
        }

        public Session Remove(int key)
        {
            Session session = _context.Sessions.Find(key);
            _context.Sessions.Remove(session);
            _context.SaveChanges();
            return session;
        }
    }
}