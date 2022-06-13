using HousingEstateManagementSystem.Entity.Dto;
using HousingEstateManagementSystem.Entity.Models;
using HousingEstateManagementSystem.Interface;
using HousingEstateManagementSystem.WepApi.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HousingEstateManagementSystem.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HouseController : ApiBaseController<IHouseService, House, DtoHouse>
    {
        private readonly IHouseService houseService;
        public HouseController(IHouseService houseService) : base(houseService)
        {
            this.houseService = houseService;
        }
    }
}
