
using Microsoft.AspNetCore.Mvc;
using ModelClassLibrary.Model;
using ModelClassLibrary.Repository.IRepository;

namespace WebApplication61.Controllers
{
    [Route("/newBooks")]
    [ApiController]
    public class BooksAsyncController : ControllerBase
    {
        private readonly IBookRepository context;

        public BooksAsyncController(IBookRepository context )
        {
            this.context = context;
        }

        [HttpGet("GetAllBooksAsync")]
        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            return await context.GetAllBooks(null);

        }

        [HttpGet("GetBookById")]
        public async Task<ActionResult<Book>> GetBookByIdAsync(int id)
        {
            return await context.GetBook(c=>c.BookId == id);

        }
    }
}
