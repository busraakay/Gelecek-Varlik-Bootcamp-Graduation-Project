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
    public interface IPaymentService : IGenericService<Payment, DtoPayment>
    {
        IResponse<List<DtoPayment>> GetIncomingPay();
        IResponse<List<DtoPayment>> GetPaidPaymentForUsers(int id);
        IResponse<List<DtoPayment>> GetPaymentForUsers(int id);
        DtoPayment GetUnPaidPaymentForUsers(int id);
    }
}
