using Microsoft.EntityFrameworkCore;
using ModelClassLibrary.Infra;
using ModelClassLibrary.Model;
using ModelClassLibrary.Repository.IRepository;
using System.Linq.Expressions;

namespace ModelClassLibrary.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext context;

        public BookRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task CreateBook(Book entity)
        {
           await context.Books.AddAsync(entity);
           await Save();
        }

        public async Task DeleteBook(Book entity)
        {
           context.Books.Remove(entity);
            await Save();
        }

   

        public async Task<Book> GetBook(Expression<Func<Book,bool>> filter = null)
        {
            IQueryable<Book> query = context.Books;
            if (filter != null)
            {
                query = query.AsNoTracking().Where(filter);
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task Save()
        {
          await  context.SaveChangesAsync();
        }

        public async Task<List<Book>> GetAllBooks(Expression<Func<Book, bool>> filter)
        {
            IQueryable<Book> query = context.Books;
            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await query.ToListAsync();
        }
    }
}
