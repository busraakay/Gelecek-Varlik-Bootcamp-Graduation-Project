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
using MongoDB.Driver;
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
    public class InvoiceController : ApiBaseController<IInvoiceService, Invoice, DtoInvoice>
    {
        private readonly IInvoiceService invoiceService;
        private readonly UserManager<User> _userManager;
        public InvoiceController(IInvoiceService invoiceService, UserManager<User> userManager) : base(invoiceService)
        {
            this.invoiceService = invoiceService;
            _userManager = userManager;
        }

        [HttpGet("GelenFaturaOdeme-Admin")]
        [Authorize(Roles = "Admin")]
        public IResponse<List<DtoInvoice>> GetIncomingPay()
        {
            try
            {
                var userMail = User.Identity.Name;
                //var user = await _userManager.FindByNameAsync(userMail);
                //var id = user.Id;
                return invoiceService.GetIncomingPay();
            }
            catch (Exception ex)
            {
                return new Response<List<DtoInvoice>>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }

        [HttpGet("KullaniciFaturalari")]
        public async Task<IResponse<List<DtoInvoice>>> IncomingPay()
        {
            try
            {
                var userMail = User.Identity.Name;
                var user = await _userManager.FindByNameAsync(userMail);
                var id = user.Id;
                return invoiceService.GetInvoiceForUsers(id);
            }
            catch (Exception ex)
            {
                return new Response<List<DtoInvoice>>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }

        [HttpGet("KullaniciOdedigiFatura")]
        public async Task<IResponse<List<DtoInvoice>>> GetPaidInvoiceForUsers()
        {
            try
            {
                var userMail = User.Identity.Name;
                var user = await _userManager.FindByNameAsync(userMail);
                var id = user.Id;
                return invoiceService.GetPaidInvoiceForUsers(id);
            }
            catch (Exception ex)
            {
                return new Response<List<DtoInvoice>>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }

        [HttpPost("FaturaOde")]
        public async Task<IResponse<DtoInvoice>> PayInvoiceAsync(CreditCardModel p)
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
                var invoice = invoiceService.GetUnPaidInvoiceForUsers(id);
                if (values.CardNumber == p.CardNumber && values.CVC == p.CVC && values.ExpireDate == p.ExpireDate)
                {
                    
                    values.Budget = values.Budget - invoice.InvoiceAmount;
                    invoice.InvoiceIsPaid = true;
                    invoiceService.Update(invoice);

                    var jsonCard = JsonConvert.SerializeObject(values);
                    var content = new StringContent(jsonCard, Encoding.UTF8, "application/json");
                    var responseMessage2 = await httpClient.PutAsync("https://localhost:44360/api/CreditCard/", content);

                    
                }

                return new Response<DtoInvoice>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = invoice
                };

            }
            catch (Exception ex)
            {
                return new Response<DtoInvoice>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }

    }
}
