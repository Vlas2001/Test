using Microsoft.EntityFrameworkCore;
using Models;
using Models.User;

namespace DatabaseContext
{
    public sealed class TestContext: DbContext 
    {
        public DbSet<User> Users { get; set; }
        
        public DbSet<Test> Tests { get; set; }
        
        public DbSet<TestItem> TestItems { get; set; }

        public TestContext(DbContextOptions<TestContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}