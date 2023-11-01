

using Jookli.BuildingBlocks.Infrastructure.EventsBus;

namespace Jookli.Games.IntegrationEvents
{
    public class TaskCompletedIntegrationEvent : IntegrationEvent
    {
        public Guid UserId { get; }
        public Guid TaskId { get; }
        public double Score { get; }
         
        public TaskCompletedIntegrationEvent(Guid id, DateTime occuredOn, Guid userId, Guid taskId, double score) : base(id, occuredOn)
        {
            UserId = userId;
            TaskId = taskId;
            Score = score;
        }
    }
}
