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
    public interface IInvoiceService : IGenericService<Invoice, DtoInvoice>
    {
        IResponse<List<DtoInvoice>> GetIncomingPay();
        IResponse<List<DtoInvoice>> GetPaidInvoiceForUsers(int id);
        IResponse<List<DtoInvoice>> GetInvoiceForUsers(int id);
        DtoInvoice GetUnPaidInvoiceForUsers(int id);

    }
}
