using AutoMapper;
using HousingEstateManagementSystem.Entity.Dto;
using HousingEstateManagementSystem.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HousingEstateManagementSystem.Entity.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<House, DtoHouse>().ReverseMap();
            CreateMap<Invoice, DtoInvoice>().ReverseMap();
            CreateMap<Message, DtoMessage>().ReverseMap();
            CreateMap<Payment, DtoPayment>().ReverseMap();
            CreateMap<User, DtoUser>().ReverseMap();
            CreateMap<User, DtoRegister>();
        }
    }
}
