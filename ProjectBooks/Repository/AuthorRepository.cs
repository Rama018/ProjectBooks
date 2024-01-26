using ProjectBooks.Data;
using ProjectBooks.Data.Entities;
using System.Linq;
using System.Linq.Expressions;

namespace ProjectBooks.Repository
{
    public class AuthorRepository : IRepository<Author>
    {
        private readonly AppDbContext _context;


        public AuthorRepository(AppDbContext context)
        {
            _context = context;

        }
        public void Add(Author entity)
        {
            _context.author.Add(entity);
        }

        public void Delete(Author entity)
        {
            _context.author.Remove(entity);
        }

        public IEnumerable<Author> GetAll()
        {
            IEnumerable<Author> author = _context.author.ToList();
            return author;
        }

        public Author GetByID(Expression<Func<Author, bool>> expression)
        {

            Author author = _context.author.Where(expression).FirstOrDefault();
            return author; 
        }

        public void Update(Author entity)
        {
            _context.author.Update(entity);

        }
    }
}
