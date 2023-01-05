using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineBookstore.Models;

namespace OnlineBookstore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        private readonly AppDbContext _appContext;

        public BooksController(AppDbContext context)
        {
            _appContext = context;
        }

        [HttpGet]
        public IAsyncEnumerable<Book> GetBooks()
        {
            return  _appContext
                .Books
                .AsAsyncEnumerable();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook(int id) {
            Book book = await _appContext
                .Books
                .Include(s => s.Authors)
                .FirstAsync(b => b.BookId == id);

            if (book.Authors != null) {
                foreach (Author a in book.Authors) {
                    a.Books = null;
                };
            }
            return Ok(book);
        }
        [HttpPost]
        public async Task<IActionResult> SaveBook([FromBody] Book book) {
            await _appContext.Books.AddAsync(book);
            await _appContext.SaveChangesAsync();
            return Ok(book);
        }
        [HttpPut]
        public async Task UpdateBook([FromBody] Book book) {
            _appContext.Update(book);
            await _appContext.SaveChangesAsync();
        }
        [HttpDelete("{id}")]
        public async Task DeleteBook(int id) {
            _appContext.Books.Remove(new Book() { BookId = id });
            await _appContext.SaveChangesAsync();
        }
    }
}
