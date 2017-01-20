using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspOnePage.Models
{
    public class UserCity
    {
        public int Id { get; set; } = -1;
        public string Title { get; set; }
        public string Value { get; set; }
        public string Language { get; set; } = "ru";

        public DateTime CreatedTime { get; set; } = DateTime.UtcNow;

        public UserCity()
        {

        }

        public UserCity(string title, string value, string language = "ru")
        {
            Title = title;
            Value = value;
            Language = language;
        }
    }
}