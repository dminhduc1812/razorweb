using Microsoft.EntityFrameworkCore;

namespace Cs_razorweb.Models;

public class MyBlogContext : DbContext
{
    public MyBlogContext(DbContextOptions<MyBlogContext> options) : base(options)
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
    
    public DbSet<Article> articles { get; set; }
}

