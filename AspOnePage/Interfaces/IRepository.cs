using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspOnePage.Interfaces
{
    public interface IRepository<T, J>
    {
        IEnumerable<T> Take(int count, int page, Func<T, bool> search, Func<T, J> order, bool desc = true);
    }
}
