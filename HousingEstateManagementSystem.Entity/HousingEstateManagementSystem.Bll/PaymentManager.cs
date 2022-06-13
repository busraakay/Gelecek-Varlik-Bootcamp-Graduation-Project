using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HousingEstateManagementSystem.Dal.Abstract;
using HousingEstateManagementSystem.Entity.Base;
using HousingEstateManagementSystem.Entity.Dto;
using HousingEstateManagementSystem.Entity.IBase;
using HousingEstateManagementSystem.Entity.Models;
using HousingEstateManagementSystem.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace HousingEstateManagementSystem.Bll
{
    public class PaymentManager : GenericManager<Payment, DtoPayment>, IPaymentService
    {
        public readonly IPaymentRepository paymentRepository;

        public PaymentManager(IServiceProvider service) : base(service)
        {
            paymentRepository = service.GetService<IPaymentRepository>();
        }

        public IResponse<List<DtoPayment>> GetIncomingPay()
        {
            try
            {
                var list = paymentRepository.GetIncomingPay();

                var listDto = list.Select(x => ObjectMapper.Mapper.Map<DtoPayment>(x)).ToList();

                return new Response<List<DtoPayment>>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = listDto
                };
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

        public IResponse<List<DtoPayment>> GetPaidPaymentForUsers(int id)
        {
            try
            {
                var list = paymentRepository.GetPaidPaymentForUsers(id);

                var listDto = list.Select(x => ObjectMapper.Mapper.Map<DtoPayment>(x)).ToList();

                return new Response<List<DtoPayment>>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = listDto
                };
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

        public IResponse<List<DtoPayment>> GetPaymentForUsers(int id)
        {
            try
            {
                var list = paymentRepository.GetPaymentForUsers(id);

                var listDto = list.Select(x => ObjectMapper.Mapper.Map<DtoPayment>(x)).ToList();

                return new Response<List<DtoPayment>>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Data = listDto
                };
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

        public DtoPayment GetUnPaidPaymentForUsers(int id)
        {
            var data = paymentRepository.GetUnPaidPaymentForUsers(id);

            return ObjectMapper.Mapper.Map<DtoPayment>(data);
        }
    }
}
