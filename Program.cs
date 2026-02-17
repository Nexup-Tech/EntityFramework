using EntityFramework.Context;
using EntityFramework.Services;
using Microsoft.EntityFrameworkCore;

var options = new DbContextOptionsBuilder<AppDbContext>()
    .UseSqlServer("Server=db41761.public.databaseasp.net; Database=db41761; User Id=db41761; Password=5t!YZ7z+3x@N; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;")
    .Options;

await using var context = new AppDbContext(options);

var bookService = new BookService(context);

while (true)
{
    var input = MenuService.ShowMenu();

    switch (input)
    {
        case "1":
            await bookService.GetAllBooksAsync();
            break;
        default:
            break;
    }
}