﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditCard.WepApi.Models
{
    public class CreditCardClass
    {
        [BsonId]
        public ObjectId CardId { get; set; }
        public string CardNumber { get; set; }
        public string CVC { get; set; }
        public string ExpireDate { get; set; }
        public string UserMail { get; set; }
        public double Budget { get; set; }
    }
}
