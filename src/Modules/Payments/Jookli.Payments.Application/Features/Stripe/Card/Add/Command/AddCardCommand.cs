﻿using Jookli.Payments.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Payments.Application.Features.Stripe.Card.Add.Command
{
    public class AddCardCommand : CommandBase
    {
        public AddCardCommand(Guid userId, string cardId, string expiryDate, string cardNumber, string cVV)
        {
            UserId = userId;
            CardId = cardId;
            ExpiryDate = expiryDate;
            CardNumber = cardNumber;
            CVV = cVV;
        }

        public Guid UserId { get; set; }
        public string CardId { get; set; }
        public string ExpiryDate { get; set; }
        public string CardNumber { get; set; }
        public string CVV { get; set; }
    }
}
