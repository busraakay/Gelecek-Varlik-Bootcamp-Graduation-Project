using HousingEstateManagementSystem.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HousingEstateManagementSystem.Dal.Abstract
{
    public interface IPaymentRepository
    {
        List<Payment> GetIncomingPay();
        List<Payment> GetPaidPaymentForUsers(int id);
        List<Payment> GetPaymentForUsers(int id);
        Payment GetUnPaidPaymentForUsers(int id);
    }
}
