using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspOnePage.Models
{
    public class Pagination
    {
        public int PagesCount => (int)Math.Ceiling((decimal)Total / (decimal)OnPage);
        public int CurrentPage { get; set; } = 1;
        public int OnPage { get; set; } = 1;
        public int Total { get; set; } = 1;

        public Pagination()
        {

        }

        public Pagination(int total, int onPage, int current)
        {
            Total = total;
            OnPage = onPage;
            CurrentPage = current;
        }
    }
}