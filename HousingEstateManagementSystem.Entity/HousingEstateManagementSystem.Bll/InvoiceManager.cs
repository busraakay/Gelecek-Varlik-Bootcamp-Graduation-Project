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
using Microsoft.AspNetCore.Http;
using HousingEstateManagementSystem.Entity.Base;

namespace HousingEstateManagementSystem.Bll
{
    public class InvoiceManager : GenericManager<Invoice, DtoInvoice>, IInvoiceService
    {
        public readonly IInvoiceRepository invoiceRepository;

        public InvoiceManager(IServiceProvider service) : base(service)
        {
            invoiceRepository = service.GetService<IInvoiceRepository>();
        }

        public IResponse<List<DtoInvoice>> GetIncomingPay()
        {
            try
            {
                var list = invoiceRepository.GetIncomingPay();

                var listDto = list.Select(x => ObjectMapper.Mapper.Map<DtoInvoice>(x)).ToList();

                return new Response<List<DtoInvoice>>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = listDto
                };
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

        public IResponse<List<DtoInvoice>> GetInvoiceForUsers(int id)
        {
            try
            {
                var list = invoiceRepository.GetInvoiceForUsers(id);

                var listDto = list.Select(x => ObjectMapper.Mapper.Map<DtoInvoice>(x)).ToList();

                return new Response<List<DtoInvoice>>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = listDto
                };
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

        public IResponse<List<DtoInvoice>> GetPaidInvoiceForUsers(int id)
        {
            try
            {
                var list = invoiceRepository.GetPaidInvoiceForUsers(id);

                var listDto = list.Select(x => ObjectMapper.Mapper.Map<DtoInvoice>(x)).ToList();

                return new Response<List<DtoInvoice>>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = listDto
                };
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

        public DtoInvoice GetUnPaidInvoiceForUsers(int id)
        {

            var data = invoiceRepository.GetUnPaidInvoiceForUsers(id);

            return ObjectMapper.Mapper.Map<DtoInvoice>(data);

        }
    }
}
