using CreditCard.WepApi.Models;
using HousingEstateManagementSystem.Entity.Base;
using HousingEstateManagementSystem.Entity.IBase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditCard.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCard : ControllerBase
    {
        [HttpPost]
        public IResponse<CreditCardClass> AddCard(CreditCardModel p)
        {
            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://busraakay6:123456Aa*@creditcardapi.wbwe7yo.mongodb.net/?retryWrites=true&w=majority");
            var client = new MongoClient(settings);
            var database = client.GetDatabase("CreditCardApi");
            var collection = database.GetCollection<CreditCardClass>("CreditCard");
            try
            {
                var card = new CreditCardClass()
                {
                    CardId = ObjectId.GenerateNewId(),
                    CardNumber = p.CardNumber,
                    CVC = p.CVC,
                    ExpireDate = p.ExpireDate,
                    UserMail = p.UserMail,
                    Budget = p.Budget
                };

                collection.InsertOne(card);

                return new Response<CreditCardClass>
                {
                    Message = "Kart üretildi.",
                    StatusCode = StatusCodes.Status200OK,
                    Data = card
                };

            }
            catch (Exception ex)
            {
                return new Response<CreditCardClass>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }

        [HttpPut]
        public IResponse<CreditCardClass> FindCard(string mail)
        {
            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://busraakay6:123456Aa*@creditcardapi.wbwe7yo.mongodb.net/?retryWrites=true&w=majority");
            var client = new MongoClient(settings);
            var database = client.GetDatabase("CreditCardApi");
            var collection = database.GetCollection<CreditCardClass>("CreditCard");
            try
            {
                var card = collection.Find(x => x.UserMail == mail).FirstOrDefault();

                return new Response<CreditCardClass>
                {
                    Message = "Kart bulundu.",
                    StatusCode = StatusCodes.Status200OK,
                    Data = card
                };

            }
            catch (Exception ex)
            {
                return new Response<CreditCardClass>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }
    }
}
