using Jookli.BuildingBlocks.Infrastructure.EventsBus;


namespace Jookli.Games.IntegrationEvents
{
    public class ProfileCreatedIntegrationEvent : IntegrationEvent
    {
        public Guid ProfileId { get; set; }
        public ProfileCreatedIntegrationEvent(Guid id, DateTime occuredOn, Guid profileId) : base(id, occuredOn)
        {
            ProfileId = profileId;
        }
    }
}
