using HousingEstateManagementSystem.Dal.Abstract;
using HousingEstateManagementSystem.Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HousingEstateManagementSystem.Dal.Concrete.EntityFramework.Repository
{
    public class PaymentRepository : GenericRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(DbContext context) : base(context)
        {

        }

        public List<Payment> GetIncomingPay()
        {
            return dbset.Include(x => x.House).Where(x => x.PaymentIsPaid == true).ToList();
        }

        public List<Payment> GetPaymentForUsers(int id)
        {
            return dbset.Include(x => x.House).Where(x => x.House.Id == id).ToList();
        }

        public List<Payment> GetPaidPaymentForUsers(int id)
        {
            return dbset.Include(x => x.House).Where(x => x.PaymentIsPaid == true && x.House.Id == id).ToList();
        }

        public Payment GetUnPaidPaymentForUsers(int id)
        {
            return dbset.Include(x => x.House).Where(x => x.PaymentIsPaid == false && x.House.Id == id).FirstOrDefault();

        }
    }
}
