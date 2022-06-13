using HousingEstateManagementSystem.Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HousingEstateManagementSystem.Entity.Models
{
    public class Message : EntityBase
    {
        [Key]
        public int MessageID { get; set; }
        public int? SenderID { get; set; }
        public int? ReceiverID { get; set; }
        public string Subject { get; set; }
        public string MessageDetails { get; set; }
        public DateTime MessageDate { get; set; }
        public string MessageStatus { get; set; }

        public User SenderUser { get; set; }
        public User ReceiverUser { get; set; }
    }
}
