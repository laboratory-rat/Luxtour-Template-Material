using AspOnePage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AspOnePage.Controllers.Api
{
    public class CitiesController : ApiController
    {
        private readonly List<UserCity> _cities = new List<UserCity>()
        {
            new UserCity("Львов", "lviv"),
            new UserCity("Киев", "kiev"),
            new UserCity("Хрьков", "harkov"),
            new UserCity("Донецк", "donetsk"),
            new UserCity("Луганск", "lugansk"),
            new UserCity("Ивано-Франковск", "i-frank"),
            new UserCity("Днепропетровск", "dnepr"),

        };

        public IEnumerable<UserCity> Get()
        {
            return _cities;
        }
    }



}
