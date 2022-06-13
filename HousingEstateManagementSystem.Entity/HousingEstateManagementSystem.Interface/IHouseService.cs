using HousingEstateManagementSystem.Entity.Dto;
using HousingEstateManagementSystem.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HousingEstateManagementSystem.Interface
{
    public interface IHouseService : IGenericService<House, DtoHouse>
    {
    }
}
