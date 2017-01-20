using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspOnePage.Models
{
    public class MessageModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public string Ip { get; set; }

        public DateTime CreatedTime { get; set; } = DateTime.UtcNow;
        public DateTime? ComplitedTime { get; set; } = null;

        public string Comennt { get; set; }

        public virtual ApplicationUser Manager { get; set; } = null;
        public bool Free => Manager == null;

        public MessageModel()
        {

        }

        public MessageModel(UserMessageModel model)
        {
            FullName = model.FullName;
            Email = model.Email;
            Message = model.Message;

            Ip = HttpContext.Current.Request.UserHostAddress;
        }
    }

    public class UserMessageModel
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }

        public UserMessageModel()
        {

        }
    }
}