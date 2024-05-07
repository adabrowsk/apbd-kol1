using Kol1.Models.DTOs;

using Microsoft.EntityFrameworkCore;
 
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
 
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<BookAuthor> BookAuthors { get; set; }
 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BookAuthor>()
            .HasKey(ba => new { ba.BookId, ba.AuthorId });
        
    }
}