using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace AuthenApi.Models
{
    public class AuthenContext : DbContext
    {
        public AuthenContext(DbContextOptions<AuthenContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Session> Sessions {get; set; }
    }

}