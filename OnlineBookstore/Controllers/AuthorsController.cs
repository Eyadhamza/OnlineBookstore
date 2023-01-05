using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineBookstore.Models;

namespace OnlineBookstore.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorsController : Controller
{
    private readonly AppDbContext _appContext;

    public AuthorsController(AppDbContext context)
    {
        _appContext = context;
    }

    [HttpGet]
    public IAsyncEnumerable<Author> GetAuthors()
    {

        return  _appContext
            .Authors
            .AsAsyncEnumerable();
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAuthor(int id) {
        Author author = await _appContext
            .Authors
            .Include(s => s.Books)
            .FirstAsync(b => b.AuthorId == id);

        foreach (Book b in author.Books) {
            b.Authors = null;
        };
        return Ok(author);
    }
    [HttpPost]
    public async Task<IActionResult> SaveAuthor([FromBody] Author author) {
        await _appContext.Authors.AddAsync(author);
        await _appContext.SaveChangesAsync();
        return Ok(author);
    }
    [HttpPut]
    public async Task UpdateAuthor([FromBody] Author author) {
        _appContext.Update(author);
        await _appContext.SaveChangesAsync();
    }
    [HttpDelete("{id}")]
    public async Task DeleteAuthor(int id) {
        _appContext.Authors.Remove(new Author() { AuthorId = id });
        await _appContext.SaveChangesAsync();
    }
}
