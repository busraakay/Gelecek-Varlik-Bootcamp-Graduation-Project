using HousingEstateManagementSystem.Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HousingEstateManagementSystem.Entity.Dto
{
    public class DtoUser : DtoBase
    {
        public string UserNameSurname { get; set; }
        public string UserTrIdentityNo { get; set; }
        public string UserEmail { get; set; }
        public string? UserVehicleInfo { get; set; }
        public string UserStatus { get; set; }
    }
}
