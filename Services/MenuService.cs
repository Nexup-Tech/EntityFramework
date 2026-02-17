namespace EntityFramework.Services;

public static class MenuService
{
    public static string ShowMenu()
    {
        string? input = null;
        while (!IsValidInput(input))
        {
            Console.WriteLine("1. Kitapları Listele");
            Console.WriteLine("2. Kitap Ekle");
            Console.WriteLine("3. Kitap Sil");
            Console.WriteLine("4. Kitap Al");
            Console.WriteLine("5. Kitap Ver");

            input = Console.ReadLine()?.Trim();
        }

        return input;
    }


    private static bool IsValidInput(string? input)
    {
        return input is "1" or "2" or "3" or "4" or "5";
    }
}