using Jookli.BuildingBlocks.Application.Outbox;

namespace Jookli.Payments.Infrastructure.Configuration.Outbox
{
    public class OutboxAccessor : IOutbox
    {
        private readonly PaymentsContext _paymentsContext;

        internal OutboxAccessor(PaymentsContext paymentContext)
        {
            _paymentsContext = paymentContext;
        }

        public void Add(OutboxMessage message)
        {
            _paymentsContext.OutboxMessages.Add(message);
        }

        public Task Save()
        {
            return Task.CompletedTask; // Save is done automatically using EF Core Change Tracking mechanism during SaveChanges.
        }
    }
}