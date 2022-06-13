using HousingEstateManagementSystem.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HousingEstateManagementSystem.Entity.Models.InvoiceTypeEnum;

namespace HousingEstateManagementSystem.Entity.Dto
{
    public class DtoInvoice : DtoBase
    {
        public int InvoiceID { get; set; }
        public InvoiceType InvoiceType { get; set; }
        public double InvoiceAmount { get; set; }
        public bool InvoiceIsPaid { get; set; }
    }
}
