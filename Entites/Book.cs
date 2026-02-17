namespace EntityFramework.Entites;

public class Book : BaseEntity
{
    public string Title { get; set; } = null!;
    public string Author { get; set; } = null!;
    public bool isAvailable { get; set; } = true;
}