using AspOnePage.Interfaces;
using AspOnePage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspOnePage.Repositories
{
    public class UserRepository : BaseRepository<ApplicationUser, string>, IUserRepository<ApplicationUser, string>
    {
        public override IEnumerable<ApplicationUser> Take(int count, int page, Func<ApplicationUser, bool> search, Func<ApplicationUser, string> order, bool desc = true)
        {
            if (desc)
                return Context.Users.Where(search).OrderByDescending(order).Take(count).Skip((page - 1) * count);

            return Context.Users.Where(search).OrderBy(order).Take(count).Skip((page - 1) * count);
        }
    }
}