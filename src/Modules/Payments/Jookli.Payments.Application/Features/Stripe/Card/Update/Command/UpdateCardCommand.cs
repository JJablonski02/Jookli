using Jookli.Payments.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Payments.Application.Features.Stripe.Card.Update.Command
{
    public class UpdateCardCommand : CommandBase
    {
        public UpdateCardCommand(Guid userId, string cardNumber, string cVV, string expiredDate, string token)
        {
            UserId = userId;
            CardNumber = cardNumber;
            CVV = cVV;
            ExpiredDate = expiredDate;
            Token = token;
        }

        public Guid UserId { get; set; }
        public string CardNumber { get; set; }
        public string CVV { get; set; }
        public string ExpiredDate { get; set; }
        public string Token { get; set; }
    }
}
