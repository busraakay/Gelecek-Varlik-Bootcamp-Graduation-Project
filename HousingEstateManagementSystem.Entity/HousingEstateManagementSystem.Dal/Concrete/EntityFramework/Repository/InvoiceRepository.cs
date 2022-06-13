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
    public class InvoiceRepository : GenericRepository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(DbContext context) : base(context)
        {

        }

        public List<Invoice> GetIncomingPay()
        {
            return dbset.Include(x => x.House).Where(x => x.InvoiceIsPaid == true).ToList();
        }

        public List<Invoice> GetInvoiceForUsers(int id)
        {
            return dbset.Include(x => x.House).Where(x => x.House.Id == id).ToList();
        }   

        public List<Invoice> GetPaidInvoiceForUsers(int id)
        {
            return dbset.Include(x => x.House).Where(x => x.InvoiceIsPaid == true && x.House.Id == id).ToList();
        }

        public Invoice GetUnPaidInvoiceForUsers(int id)
        {
            return dbset.Include(x => x.House).Where(x => x.InvoiceIsPaid == false && x.House.Id == id).FirstOrDefault();
        }
    }
}
