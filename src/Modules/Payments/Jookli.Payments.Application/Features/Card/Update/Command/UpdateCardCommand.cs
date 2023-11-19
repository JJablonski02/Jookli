using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Payments.Application.Features.Card.Update.Command
{
    internal class UpdateCardCommand
    {
        public Guid UserId { get; set; }
        public string CardNumber { get; set; }
        public string CVV { get; set; }
        public string ExpiredDate { get; set; }
        public string Token { get; set; }
    }
}
