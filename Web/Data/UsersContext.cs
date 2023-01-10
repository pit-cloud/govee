using Azure.Core;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Web
{
    public class UsersContext : DbContext
    {
        public UsersContext(DbContextOptions<UsersContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
    }

    public class User
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string ApiKey { get; set; }
    }
}
