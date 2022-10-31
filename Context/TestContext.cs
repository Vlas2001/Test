using Microsoft.EntityFrameworkCore;
using Models.User;

namespace Context
{
    public class TestContext: DbContext 
    {
        public DbSet<User> Users { get; set; }

        public TestContext(DbContextOptions<TestContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}