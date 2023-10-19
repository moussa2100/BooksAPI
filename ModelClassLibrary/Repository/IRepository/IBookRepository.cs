using ModelClassLibrary.Model;
using System.Linq.Expressions;

namespace ModelClassLibrary.Repository.IRepository
{
    public interface IBookRepository
    {
        Task CreateBook(Book entity);

        Task DeleteBook(Book entity);

        Task<List<Book>> GetAllBooks(Expression<Func<Book,bool>> filter = null );

        Task<Book> GetBook(Expression<Func<Book,bool>> filter = null);
        Task Save();
    }
}
