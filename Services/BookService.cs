using EntityFramework.Context;
using EntityFramework.Entites;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.Services;

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
        var title = GetTextInput();

        Console.WriteLine("Yazar Adi:");
        var author = GetTextInput();

        await context.Books.AddAsync(new Book { Title = title, Author = author });
        await context.SaveChangesAsync();
        return true;
    }

    public async Task DeleteBookAsync()
    {
        Console.WriteLine("Silinecek Kitap Id'si:");
        int id = GetIntInput();

        var book = await context.Books.FindAsync(id);
        if (book == null)
        {
            Console.WriteLine("Kitap bulunamadi.");
            return;
        }

        context.Books.Remove(book);
        await context.SaveChangesAsync();
    }

    public async Task BorrowBookAsync()
    {
        Console.WriteLine("Odunc alinacak Kitap Id'si:");
        int id = GetIntInput();

        var book = await context.Books.FindAsync(id);
        if (book == null)
        {
            Console.WriteLine("Kitap bulunamadi.");
            return ;
        }

        if (!book.isAvailable)
        {
            Console.WriteLine("Kitap zaten odunc alinmis.");
            return ;
        }

        book.isAvailable = false;
        await context.SaveChangesAsync();

    }

    public async Task ReturnBookAsync()
    {
        Console.WriteLine("İade edilecek Kitap Id'si:");
        int id = GetIntInput();

        var book = await context.Books.FindAsync(id);
        if (book == null)
        {
            Console.WriteLine("Kitap bulunamadi.");
            return ;
        }

        if (book.isAvailable)
        {
            Console.WriteLine("Kitap zaten iade edilmis.");
            return ;
        }

        book.isAvailable = true;
        await context.SaveChangesAsync();

    }


    private static string GetTextInput()
    {
        var input = string.Empty;
        
        while (string.IsNullOrEmpty(input)) 
        {
            input = Console.ReadLine()?.Trim() ?? string.Empty;
            
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Gecersiz girdi. Lutfen tekrar deneyin.");
            }
        }
        
        return input;
    }


    private static int GetIntInput()
    {
        int input;
        
        while (!int.TryParse(Console.ReadLine(), out input))
        {
            Console.WriteLine("Gecersiz girdi. Tekrar Deneyiniz");
        }
        
        return input;
    }
}