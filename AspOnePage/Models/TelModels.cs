using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspOnePage.Models
{
    public class Call
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Tel { get; set; }

        public string Ip { get; set; }

        public DateTime Created { get; set; } = DateTime.UtcNow;
        public DateTime? CallTime { get; set; }
        public DateTime? Complited { get; set; } = null;
        public bool Finished => Complited != null;


        public DateTime? TakeTime { get; set; } = null;
        public virtual ApplicationUser Manager { get; set; } = null;
        public bool IsFree => Manager == null;
        public string Comment { get; set; }


        public Call()
        {

        }

        public Call(CallModel model)
        {
            FullName = model.Name;
            Tel = model.Tel;

            Ip = HttpContext.Current.Request.UserHostAddress;

            CallTime = model.CallTime == null ? null : model.CallTime;
        }

        public void Grub(ApplicationUser user)
        {
            Manager = user;
            TakeTime = DateTime.UtcNow;
        }

        public void Finish(string comment = "")
        {
            Complited = DateTime.UtcNow;
            Comment = comment;
        }
    }

    public class CallModel
    {
        public string Name { get; set; }
        public string Tel { get; set; }
        public DateTime? CallTime { get; set; }

        public CallModel()
        {

        }
    }
}