using HousingEstateManagementSystem.Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HousingEstateManagementSystem.Entity.Models
{
    public class Payment : EntityBase
    {
        [Key]
        public int PaymentID { get; set; }
        public double PaymentAmount { get; set; }
        public bool PaymentIsPaid { get; set; }
        public DateTime PaymentDate{ get; set; }


          
        public int HouseId { get; set; }
        public House House { get; set; }
    }
}
