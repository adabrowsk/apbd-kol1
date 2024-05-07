using Kol1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Kol1.Models.DTOs;


namespace Kol1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly ApplicationDbContext _context;
 
    public BooksController(ApplicationDbContext context)
    {
        _context = context;
    }
 
  
    [HttpGet("{id}/authors")]
    public async Task<ActionResult<Book>> GetBookAuthors(int id)
    {
        var book = await _context.Books
            .Where(b => b.Id == id)
            .Include(b => b.BookAuthors)!
            .ThenInclude(ba => ba.Author)
            .FirstOrDefaultAsync();
 
        if (book == null)
        {
            return NotFound();
        }
 
        return Ok(new
        {
id = book.Id,
            title = book.Title,
            authors = book.BookAuthors.Select(ba => new
            {
                firstName = ba.Author.FirstName,
                lastName = ba.Author.LastName
            })
        });
    }
 
    [HttpPost]
    public async Task<ActionResult<Book>> PostBook([FromBody] Book book)
    {
        _context.Books.Add(book);
        await _context.SaveChangesAsync();
 
return CreatedAtAction("GetBookAuthors", new { id = book.Id }, book);
    }
}
