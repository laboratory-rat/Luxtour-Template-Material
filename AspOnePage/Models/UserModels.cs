using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspOnePage.Models
{
    public class UserLogin
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }

    public class UserShort
    {
        public string Id { get; set; } = "";
        public string ShortId => Id == "" ? "" : Id.Substring(0, 10);
        public bool Lockout { get; set; }
        public DateTime? LockoutEndDate { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string  Tel { get; set; }

        public UserShort()
        {

        }

        public UserShort(ApplicationUser data)
        {
            Id = data.Id;
            Lockout = data.LockoutEnabled;
            LockoutEndDate = data.LockoutEndDateUtc;
            FirstName = data.FirstName;
            SecondName = data.SecondName;
            Email = data.Email;
            EmailConfirmed = data.EmailConfirmed;
            Tel = data.PhoneNumber;
        }
    }


    public class UserList
    {
        public List<UserShort> List { get; set; }
        public Pagination Pagination { get; set; }

        public UserList()
        {

        }

        public UserList(IEnumerable<ApplicationUser> data, int total, int page = 1)
        {
            List = new List<UserShort>(data.Select(x => new UserShort(x)).ToList());
            Pagination = new Pagination(total, List.Count, page);
        }
    }
}