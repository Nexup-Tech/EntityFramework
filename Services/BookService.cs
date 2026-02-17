using EntityFramework.Context;
using EntityFramework.Entites;
using Microsoft.EntityFrameworkCore;

public class BookService(AppDbContext context)
{
    public async Task GetAllBooksAsync()
    {
        var books = await context.Books.ToListAsync();
        foreach (var book in books)
        {
            Console.WriteLine($"Id: {book.Id}, Title: {book.Title}, Author: {book.Author}, IsAvailable: {book.isAvailable}");
        }
    }

    public async Task<bool> CreateBookAsync()
    {
        Console.WriteLine("Kitap Adi:");
        string title = Console.ReadLine() ?? string.Empty;
        Console.WriteLine("Yazar Adi:");
        string author = Console.ReadLine() ?? string.Empty;
        await context.Books.AddAsync(new Book { Title = title, Author = author });
        int Result= await context.SaveChangesAsync();
        return true;
    }
    
    public async Task<bool> DeleteBookAsync()
    {
        Console.WriteLine("Silinecek Kitap Id'si:");
        int id = int.Parse(Console.ReadLine() ?? "0");
         var book = await context.Books.FindAsync(id);
        if (book == null)        {
            Console.WriteLine("Kitap bulunamadi.");
            return false;
        }
        context.Books.Remove(book);
        await context.SaveChangesAsync();
        return true;
    }
    
    public async Task<bool> BorrowBookAsync()
    {
        Console.WriteLine("Odunc alinacak Kitap Id'si:");
        int id = int.Parse(Console.ReadLine() ?? "0");
        var book = await context.Books.FindAsync(id);
        if (book == null)        {
            Console.WriteLine("Kitap bulunamadi.");
            return false;
        }
        if (!book.isAvailable)        {
            Console.WriteLine("Kitap zaten odunc alinmis.");
            return false;
        }
        book.isAvailable = false;
        await context.SaveChangesAsync();
        return true;
    }
    
    public async Task<bool> ReturnBookAsync()
    {
        Console.WriteLine("İade edilecek Kitap Id'si:");
        int id = int.Parse(Console.ReadLine() ?? "0");
        var book = await context.Books.FindAsync(id);
        if (book == null)        {
            Console.WriteLine("Kitap bulunamadi.");
            return false;
        }
        if (book.isAvailable)        {
            Console.WriteLine("Kitap zaten iade edilmis.");
            return false;
        }
        book.isAvailable = true;
        await context.SaveChangesAsync();
        return true;
    }
}