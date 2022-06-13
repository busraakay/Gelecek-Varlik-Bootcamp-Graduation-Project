using HousingEstateManagementSystem.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HousingEstateManagementSystem.Dal.Abstract
{
    public interface IMessageRepository
    {
        List<Message> GetInBoxWithMessageByUser(int id);
        List<Message> GetSendBoxWithMessageByUser(int id);
    }
}
