using HousingEstateManagementSystem.Dal.Abstract;
using HousingEstateManagementSystem.Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HousingEstateManagementSystem.Dal.Concrete.EntityFramework.Repository
{
    public class MessageRepository : GenericRepository<Message>, IMessageRepository
    {
        public MessageRepository(DbContext context) : base(context)
        {

        }

        public List<Message> GetInBoxWithMessageByUser(int id)
        {
            return dbset.Include(x => x.SenderUser).Where(x => x.ReceiverID == id).ToList();
            //using (var c = new Context())
            //{
            //    return c.Messages.Include(x => x.SenderUser).Where(x => x.ReceiverID == id).ToList();

            //}
        }

        public List<Message> GetSendBoxWithMessageByUser(int id)
        {
            return dbset.Include(x => x.ReceiverUser).Where(x => x.SenderID == id).ToList();
            //using (var c = new Context())
            //{
            //    return c.Messages.Include(x => x.ReceiverUser).Where(x => x.SenderID == id).ToList();
            //}
        }
    }
}
