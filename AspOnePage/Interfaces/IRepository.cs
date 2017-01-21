using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AspOnePage.Interfaces
{
    public interface IRepository<T, J> : IDisposable
    {
        // Take

        IEnumerable<T> Take(int count, int page, Func<T, bool> search, Func<T, J> order, bool desc = true);
        IEnumerable<T> All(Func<T, bool> search, Func<T, J> order, bool desc);
        // Find

        T Find(Func<T, bool> search);
        Task<T> FindAsync(Expression<Func<T, bool>> search);

        // Add

        Task AddAsync(T data);
        void Add(T data);
    }
}
