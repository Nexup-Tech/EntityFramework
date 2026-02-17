using EntityFramework.Entites;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.Context;

public class AppDbContext : DbContext
{
    public DbSet<Book> Books { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;


    public AppDbContext() { }
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(
                "Server=db41761.public.databaseasp.net; Database=db41761; User Id=db41761; Password=5t!YZ7z+3x@N; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;");
        }
    }
}