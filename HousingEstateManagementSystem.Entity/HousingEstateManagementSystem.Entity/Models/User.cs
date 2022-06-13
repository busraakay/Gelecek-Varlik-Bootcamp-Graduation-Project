using HousingEstateManagementSystem.Entity.Base;
using HousingEstateManagementSystem.Entity.IBase;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HousingEstateManagementSystem.Entity.Models
{
    public class User : IdentityUser<int>
    {
        public string UserNameSurname { get; set; }
        public string UserTrIdentityNo { get; set; }
        public string UserEmail { get; set; }
        public string? UserVehicleInfo { get; set; }
        public string UserStatus { get; set; }

        public virtual ICollection<Message> UserSender { get; set; }
        public virtual ICollection<Message> UserReceiver { get; set; }
        public virtual ICollection<House> Houses { get; set; }
    }
}
