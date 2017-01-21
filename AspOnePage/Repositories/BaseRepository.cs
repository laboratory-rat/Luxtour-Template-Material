using AspOnePage.Interfaces;
using AspOnePage.Models;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;

namespace AspOnePage.Repositories
{
    public class BaseRepository<T, J> : IDisposable, IRepository<T, J> where T : class
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

        protected DbSet<T> _db { get; set; }

        public BaseRepository()
        {

        }

        #region Take
        public virtual IEnumerable<T> Take(int count, int page, Func<T, bool> search, Func<T, J> order, bool desc = true)
        {
            if (desc)
                return _db.Where(search).OrderByDescending(order).Skip((page - 1) * count).Take(count);

            return _db.Where(search).OrderBy(order).Skip((page - 1) * count).Take(count);
        }

        public virtual IEnumerable<T> All (Func<T, bool> search, Func<T, J> order, bool desc)
        {
            var l = _db.Where(search).OrderBy(order).ToArray();

            if (desc)
                l = l.Reverse().ToArray();

            return l;
        }
        #endregion



        #region Add

        public virtual void Add(T data)
        {
            _db.Add(data);
            Context.SaveChanges();
        }

        public virtual async Task AddAsync(T data)
        {
            _db.Add(data);
            await Context.SaveChangesAsync();
        }

        #endregion

        #region Find
        public virtual T Find(Func<T, bool> search)
        {
            return _db.FirstOrDefault(search);
        }

        public virtual async Task<T> FindAsync(Expression<Func<T, bool>> search)
        {
            return await _db.FirstOrDefaultAsync(search, new System.Threading.CancellationToken());
        }

        #endregion



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