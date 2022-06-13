using HousingEstateManagementSystem.Dal.Abstract;
using HousingEstateManagementSystem.Entity.Dto;
using HousingEstateManagementSystem.Entity.Models;
using HousingEstateManagementSystem.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace HousingEstateManagementSystem.Bll
{
    public class HouseManager : GenericManager<House, DtoHouse>, IHouseService
    {
        public readonly IHouseRepository houseRepository;

        public HouseManager(IServiceProvider service) : base(service)
        {
            houseRepository = service.GetService<IHouseRepository>();
        }
    }
}
