using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HousingEstateManagementSystem.Entity.Dto
{
    public class DtoMessageForAdmin
    {
        public string ReceiverMail { get; set; }
        public string Subject { get; set; }
        public string MessageDetails { get; set; }
    }
}
