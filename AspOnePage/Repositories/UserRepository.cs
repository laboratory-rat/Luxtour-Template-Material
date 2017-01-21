using AspOnePage.Interfaces;
using AspOnePage.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AspOnePage.Repositories
{
    public class UserRepository : BaseRepository<ApplicationUser, string>, IUserRepository<ApplicationUser, string>
    {
        public UserRepository()
        {
            _db = Context.Users as DbSet<ApplicationUser>;
        }

    }
}