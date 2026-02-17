using EntityFramework.Context;
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
        // Kitap bilgilerini kullanıcıdan al
        // kitap nesnesi 'new'lenecek ve context'e eklenecek
        // context.SaveChangesAsync() çağrılacak

        return true;
    }
    
    public async Task<bool> DeleteBookAsync()
    {
        
        // Silinecek kitabın Id'si kullanıcıdan alınacak
        // Kitap bulunacak ve silinecek
        // context.SaveChangesAsync() çağrılacak
        return true;
    }
    
    public async Task<bool> BorrowBookAsync()
    {
        // Ödünç alınacak kitabın Id'si kullanıcıdan alınacak
        // Kitap bulunacak ve isAvailable false yapılacak
        // context.SaveChangesAsync() çağrılacak
        return true;
    }
    
    public async Task<bool> ReturnBookAsync()
    {
        // İade edilecek kitabın Id'si kullanıcıdan alınacak
        // Kitap bulunacak ve isAvailable true yapılacak
        // context.SaveChangesAsync() çağrılacak
        return true;
    }
}