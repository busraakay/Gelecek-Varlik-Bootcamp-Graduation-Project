using HousingEstateManagementSystem.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HousingEstateManagementSystem.Dal.Abstract
{
    public interface IInvoiceRepository
    {
        List<Invoice> GetIncomingPay();
        List<Invoice> GetPaidInvoiceForUsers(int id);
        List<Invoice> GetInvoiceForUsers(int id);
        Invoice GetUnPaidInvoiceForUsers(int id);

    }
}
