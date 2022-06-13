using HousingEstateManagementSystem.Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HousingEstateManagementSystem.Entity.Models
{
    public class House : EntityBase
    {
        [Key]
        public int HouseID { get; set; }
        public int HouseNo { get; set; }
        public string HouseBlock { get; set; }
        public string HouseFloor { get; set; }
        public string HouseType { get; set; }
        public string HouseStatus { get; set; }
        public bool HouseIsOwner { get; set; }
        public bool HouseIsEmpty { get; set; }

        public int Id { get; set; }
        public User User { get; set; }

        public List<Payment> Payments { get; set; }
        public List<Invoice> Invoices { get; set; }
    }
}
