using Microsoft.AspNetCore.Mvc;
using ModelClassLibrary.Infra;
using ModelClassLibrary.Model;

namespace WebApplication61.Controllers
{
    [Route("/books")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly AppDbContext context;
        private readonly ILogger<Book> logger;

        public BookController(AppDbContext context,ILogger<Book> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        [HttpGet("GetBooks")]
        [ProducesResponseType(200)]
        public ActionResult<IEnumerable<Book>> GetBooks()
        {
            List<Book> books = context.Books.ToList();


            return Ok(books);

        }

        [HttpGet("GetBookById/{id:int}", Name = "GetBookById")]
        [ProducesResponseType(200,Type =typeof(Book))]
        [ProducesResponseType(404)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Book> GetBookById(int id)
        {
            Book book = context.Books.FirstOrDefault(c=> c.BookId==id);
           

            if (id == 0)
            {
                return BadRequest();
            }
            if (book == null)
            {
                return NotFound();
            }

            logger.LogInformation($"Find Book {id }");
            return Ok(book);
        }



        [HttpPost()]
        public ActionResult<Book> CreateBook([FromBody] Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            context.Books.Add(book);
            context.SaveChanges();
            return CreatedAtRoute("GetBookById",new {id = book.BookId }, book);
        }


        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult DeleteBook(int id)
        {
            Book book = context.Books.FirstOrDefault(c=> c.BookId==id);
            context.Books.Remove(book); 
            context.SaveChanges();
            return NoContent();
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<Book> UpdateBook(Book book)
        {
            context.Books.Update(book);
            context.SaveChanges();

            return Ok(book);
        }





    }
}
