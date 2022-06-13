using HousingEstateManagementSystem.Entity.Base;
using HousingEstateManagementSystem.Entity.Dto;
using HousingEstateManagementSystem.Entity.IBase;
using HousingEstateManagementSystem.Entity.Models;
using HousingEstateManagementSystem.Interface;
using HousingEstateManagementSystem.WepApi.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HousingEstateManagementSystem.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ApiBaseController<IMessageService, Message, DtoMessage>
    {
        private readonly IMessageService messageService;
        private readonly UserManager<User> _userManager;
        public MessageController(IMessageService messageService, UserManager<User> userManager) : base(messageService)
        {
            this.messageService = messageService;
            _userManager = userManager;
        }

        [HttpGet("InBox")]
        public async Task<IResponse<List<DtoMessage>>> InBox()
        {
            try
            {
                var userMail = User.Identity.Name;
                var user = await _userManager.FindByNameAsync(userMail);
                var id = user.Id;
                return messageService.GetInBoxWithMessageByUser(id);
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

        [HttpGet("SendBox")]
        public async Task<IResponse<List<DtoMessage>>> SendBox()
        {
            try
            {
                var userMail = User.Identity.Name;
                var user = await _userManager.FindByNameAsync(userMail);
                var id = user.Id;
                return messageService.GetSendBoxWithMessageByUser(id);
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

        [HttpPost("MesajGonder-Admin")]
        [Authorize(Roles = "Admin")]
        public async Task<IResponse<DtoMessage>> SendMessageForAdmin(DtoMessageForAdmin p)
        {
            try
            {
                DtoMessage m = new DtoMessage();

                var userMail = User.Identity.Name;
                var user = await _userManager.FindByNameAsync(userMail);
                var id = user.Id;
                m.SenderID = id;
                m.MessageStatus = "Okunmadı";
                m.MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                m.Subject = p.Subject;
                m.MessageDetails = p.MessageDetails;
                var receiverMail = await _userManager.FindByNameAsync(p.ReceiverMail);
                m.ReceiverID = receiverMail.Id;


                return messageService.Add(m);
            }
            catch (Exception ex)
            {
                return new Response<DtoMessage>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }

        [HttpPost("MesajGonder-Kullanici")]
        public async Task<IResponse<DtoMessage>> SendMessageForUsers(DtoMessageForUsers p)
        {
            try
            {
                DtoMessage m = new DtoMessage();
                var userMail = User.Identity.Name;
                var user = await _userManager.FindByNameAsync(userMail);
                var id = user.Id;
                m.SenderID = id;
                m.ReceiverID = 2;
                m.MessageStatus = "Okunmadı";
                m.MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                m.Subject = p.Subject;
                m.MessageDetails = p.MessageDetails;

                return messageService.Add(m);
            }
            catch (Exception ex)
            {
                return new Response<DtoMessage>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }
    }
}
