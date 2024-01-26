using Microsoft.EntityFrameworkCore;
using ProjectBooks.Data;
using ProjectBooks.Data.Entities;
using System.Linq.Expressions;

namespace ProjectBooks.Repository
{
    public class BookRepository : IRepository<Book>
    {
        private readonly AppDbContext _context;

                  
        public BookRepository(AppDbContext context)
        {
            _context = context;

        }

        public void Add(Book entity)
        {
            
            _context.books.Add(entity);
        }

        public void Delete(Book entity)
        {
            _context.books.Remove(entity);
        }

        public IEnumerable<Book> GetAll()
        {
            IEnumerable<Book> book = _context.books.ToList();
            return book;
        }

        public Book GetByID(Expression<Func<Book, bool>> expression)
        {
            Book book = _context.books.Where(expression).FirstOrDefault();
            return book;;
        }

        public void Update(Book entity)
        {
            _context.books.Update(entity);
        }
    }
}
