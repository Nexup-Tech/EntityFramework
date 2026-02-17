using EntityFramework.Context;
using Microsoft.EntityFrameworkCore;

var options = new DbContextOptionsBuilder<AppDbContext>()
    .UseSqlServer("Server=db41761.public.databaseasp.net; Database=db41761; User Id=db41761; Password=5t!YZ7z+3x@N; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;")
    .Options;

await using var context = new AppDbContext(options);



var books = await context.Books.ToListAsync();

foreach (var book in books)
{
    Console.WriteLine($"Kitap Id: {book.Id} -- Kitap Adi: {book.Title} -- Yazar Adi: {book.Author}");
}

