using HousingEstateManagementSystem.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HousingEstateManagementSystem.Entity.Dto
{
    public class DtoHouse : DtoBase
    {
        public int HouseID { get; set; }
        public int HouseNo { get; set; }
        public string HouseBlock { get; set; }
        public string HouseFloor { get; set; }
        public string HouseType { get; set; }
        public string HouseStatus { get; set; }
        public bool HouseIsOwner { get; set; }
        public bool HouseIsEmpty { get; set; }
    }
}
