using Jookli.Administrator.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.Administrator.Infrastructure.Configuration.Processing.Outbox
{
    public class ProcessOutboxCommand : CommandBase, IRecurringCommand
    {
    }
}
