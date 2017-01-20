using AspOnePage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspOnePage.Interfaces
{
    interface IMessageRepository<T, J> : IRepository<T, J>
    {
    }
}
