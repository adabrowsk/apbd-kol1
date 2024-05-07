namespace Kol1.Models.DTOs;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public List<Author> Authors { get; set; }
    public List<BookAuthor>? BookAuthors { get; set; }
}