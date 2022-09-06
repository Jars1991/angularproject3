using Microsoft.EntityFrameworkCore;
using Test.Models;

namespace Test.Data
{

    public class TestDbContext : DbContext
    {
        public TestDbContext(DbContextOptions<TestDbContext> options)
        : base(options) { }


        public DbSet<Director> Directors { get; set; } = null!;
        public DbSet<Movie> Movies { get; set; } = null!;

    }
}
