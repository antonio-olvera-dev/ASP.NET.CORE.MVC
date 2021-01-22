using ASP.NET.CORE.MVC.Models;
using Microsoft.EntityFrameworkCore;


namespace ASP.NET.CORE.MVC.Data
{
    public class UsersContext : DbContext
    {
        public UsersContext(DbContextOptions<UsersContext> options) : base(options)
        {

        }

        public DbSet<SignIn> SignIn { get; set; }

    }
}
