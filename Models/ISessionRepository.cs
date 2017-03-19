namespace AuthenApi.Models
{
    public interface ISessionRepository
    {
        Session Add(int userid);
        Session Remove(int key);
        Session Find(int key);
    }
}