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
    public class HouseRepository : GenericRepository<House>, IHouseRepository
    {
        public HouseRepository(DbContext context) : base(context)
        {

        }

        
    }
}
