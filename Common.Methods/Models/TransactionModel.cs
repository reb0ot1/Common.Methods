﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Methods.Models
{
    public class TransactionModel
    {
        public Guid Id { get; set; }

        public DateTime CreateOn { get; set; }

        public DateTime ModifyOn { get; set; }

        public int UserId { get; set; }

        public int MarketId { get; set; }

        public int CategoryId { get; set; }

        public double Amount { get; set; }

        public string AdditionalNote { get; set; }
    }
}
