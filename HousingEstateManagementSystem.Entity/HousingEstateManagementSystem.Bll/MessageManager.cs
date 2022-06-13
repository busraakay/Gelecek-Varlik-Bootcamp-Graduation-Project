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
using HousingEstateManagementSystem.Entity.IBase;
using HousingEstateManagementSystem.Entity.Base;
using Microsoft.AspNetCore.Http;

namespace HousingEstateManagementSystem.Bll
{
    public class MessageManager : GenericManager<Message, DtoMessage>, IMessageService
    {
        public readonly IMessageRepository messageRepository;

        public MessageManager(IServiceProvider service) : base(service)
        {
            messageRepository = service.GetService<IMessageRepository>();
        }

        public IResponse<List<DtoMessage>> GetInBoxWithMessageByUser(int id)
        {
            try
            {
                var list = messageRepository.GetInBoxWithMessageByUser(id);

                var listDto = list.Select(x => ObjectMapper.Mapper.Map<DtoMessage>(x)).ToList();

                return new Response<List<DtoMessage>>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = listDto
                };
            }
            catch (Exception ex)
            {
                return new Response<List<DtoMessage>>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }

        public IResponse<List<DtoMessage>> GetSendBoxWithMessageByUser(int id)
        {
            try
            {
                var list = messageRepository.GetSendBoxWithMessageByUser(id);

                var listDto = list.Select(x => ObjectMapper.Mapper.Map<DtoMessage>(x)).ToList();

                return new Response<List<DtoMessage>>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = listDto
                };
            }
            catch (Exception ex)
            {
                return new Response<List<DtoMessage>>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }
    }
}
