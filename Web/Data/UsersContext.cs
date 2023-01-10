using Microsoft.EntityFrameworkCore;

namespace Web
{
    public class UsersContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=pitsqlgovee.database.windows.net;Database=pit-sql-govee;Integrated Security=false;User ID=goveeadmin;Password=ChelseaFC1995>?<;");
        }
    }

    public class User
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string ApiKey { get; set; }
    }
}
