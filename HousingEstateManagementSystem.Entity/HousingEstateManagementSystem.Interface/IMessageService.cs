using HousingEstateManagementSystem.Entity.Dto;
using HousingEstateManagementSystem.Entity.IBase;
using HousingEstateManagementSystem.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HousingEstateManagementSystem.Interface
{
    public interface IMessageService : IGenericService<Message, DtoMessage>
    {
        IResponse<List<DtoMessage>> GetInBoxWithMessageByUser(int id);
        IResponse<List<DtoMessage>> GetSendBoxWithMessageByUser(int id);
    }
}
