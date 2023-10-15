using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jookli.BuildingBlocks.Application.Outbox
{
    public interface IOutbox
    {
        void Add(OutboxMessage message);
        Task Save();
    }
}
