using CreditCard.WepApi.Models;
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
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HousingEstateManagementSystem.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ApiBaseController<IPaymentService, Payment, DtoPayment>
    {
        private readonly IPaymentService paymentService;
        private readonly UserManager<User> _userManager;
        public PaymentController(IPaymentService paymentService, UserManager<User> userManager) : base(paymentService)
        {
            this.paymentService = paymentService;
            _userManager = userManager;
        }

        [HttpGet("GelenAidatOdeme-Admin")]
        [Authorize(Roles = "Admin")]
        public IResponse<List<DtoPayment>> GetIncomingPay()
        {
            try
            {
                var userMail = User.Identity.Name;
                //var user = await _userManager.FindByNameAsync(userMail);
                //var id = user.Id;
                return paymentService.GetIncomingPay();
            }
            catch (Exception ex)
            {
                return new Response<List<DtoPayment>>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }

        [HttpGet("KullaniciAidatlari")]
        public async Task<IResponse<List<DtoPayment>>> IncomingPay()
        {
            try
            {
                var userMail = User.Identity.Name;
                var user = await _userManager.FindByNameAsync(userMail);
                var id = user.Id;
                return paymentService.GetPaymentForUsers(id);
            }
            catch (Exception ex)
            {
                return new Response<List<DtoPayment>>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }

        [HttpGet("KullaniciOdedigiAidat")]
        public async Task<IResponse<List<DtoPayment>>> GetPaidInvoiceForUsers()
        {
            try
            {
                var userMail = User.Identity.Name;
                var user = await _userManager.FindByNameAsync(userMail);
                var id = user.Id;
                return paymentService.GetPaidPaymentForUsers(id);
            }
            catch (Exception ex)
            {
                return new Response<List<DtoPayment>>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }

        [HttpPost("AidatOde")]
        public async Task<IResponse<DtoPayment>> PayPaymentAsync(CreditCardModel p)
        {
            try
            {
                var userMail = User.Identity.Name;
                var user = await _userManager.FindByNameAsync(userMail);
                var id = user.Id;
                var httpClient = new HttpClient();
                var responseMessage = await httpClient.GetAsync("https://localhost:44360/api/CreditCard/" + userMail);
                var jsonString = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<CreditCardClass>(jsonString);
                var payment = paymentService.GetUnPaidPaymentForUsers(id);
                if (values.CardNumber == p.CardNumber && values.CVC == p.CVC && values.ExpireDate == p.ExpireDate)
                {

                    values.Budget = values.Budget - payment.PaymentAmount;
                    payment.PaymentIsPaid = true;
                    paymentService.Update(payment);

                    var jsonCard = JsonConvert.SerializeObject(values);
                    var content = new StringContent(jsonCard, Encoding.UTF8, "application/json");
                    var responseMessage2 = await httpClient.PutAsync("https://localhost:44360/api/CreditCard/", content);


                }

                return new Response<DtoPayment>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = payment
                };

            }
            catch (Exception ex)
            {
                return new Response<DtoPayment>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }
    }
}
