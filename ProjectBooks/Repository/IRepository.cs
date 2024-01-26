using System.Linq.Expressions;

namespace ProjectBooks.Repository
{
    public interface IRepository <T> where T : class
    {
        T GetByID(Expression<Func<T, bool>> expression); //When you combine these two together, Expression<Func<T, bool>> means that you are defining an expression tree that represents a lambda expression which takes an argument of type T and returns a boolean value.
                                                         //used for defining filter conditions or predicates that can be used in LINQ queries or other scenarios where you need to represent a condition as data.
        IEnumerable<T> GetAll();

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);


    }
}
