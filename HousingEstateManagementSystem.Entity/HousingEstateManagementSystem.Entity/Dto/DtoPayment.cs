using HousingEstateManagementSystem.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HousingEstateManagementSystem.Entity.Dto
{
    public class DtoPayment : DtoBase
    {
        public int PaymentID { get; set; }
        public double PaymentAmount { get; set; }
        public bool PaymentIsPaid { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
