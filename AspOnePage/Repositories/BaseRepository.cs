using AspOnePage.Interfaces;
using AspOnePage.Models;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspOnePage.Repositories
{
    public class BaseRepository<T, J> : IRepository<T, J>, IDisposable
    {
        protected ApplicationDbContext _context { get; set; } = null;
        public ApplicationDbContext Context
        {
            get
            {
                if (_context == null)
                    _context = HttpContext.Current.GetOwinContext().Get<ApplicationDbContext>();

                return _context;
            }
            set { _context = value; }
        }



        public virtual IEnumerable<T> Take(int count, int page, Func<T, bool> search, Func<T, J> order, bool desc = true)
        {
            throw new NotImplementedException();
        }

        #region Dis

        public virtual void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        #endregion
    }
}