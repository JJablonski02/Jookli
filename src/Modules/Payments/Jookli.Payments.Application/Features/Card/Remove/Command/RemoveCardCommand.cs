using Jookli.Payments.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Payments.Application.Features.Card.Remove.Command
{
    public class RemoveCardCommand : CommandBase
    {
        public RemoveCardCommand()
        {

        }

        public Guid UserId { get; set; }
    }
}
