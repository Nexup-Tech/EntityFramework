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
                "Server=db41759.public.databaseasp.net; Database=db41759; User Id=db41759; Password=Xa6?=7BqdT!4; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;");
        }
    }
}