using AspOnePage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspOnePage.Interfaces
{
    public interface IUserRepository<T, J> : IRepository<T, J>
    {
    }
}
