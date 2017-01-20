using AspOnePage.Interfaces;
using AspOnePage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspOnePage.Repositories
{
    public class MessageRepository : BaseRepository<MessageModel, int>,  IMessageRepository<MessageModel, int> 
    {
        public override IEnumerable<MessageModel> Take(int count, int page, Func<MessageModel, bool> search, Func<MessageModel, int> order, bool desc = true)
        {
            if(desc)
                return Context.Messages.Where(search).OrderByDescending(order).Skip((page - 1) * count).Take(count).ToList();

            return Context.Messages.Where(search).OrderBy(order).Skip((page - 1) * count).Take(count).ToList();
        }
    }
}