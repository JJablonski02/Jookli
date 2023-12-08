using Jookli.BuildingBlocks.Domain;

namespace Jookli.Commander.Domain.Entites.EmailTemplate
{
    public class EmailTemplateAttachedEntity : Entity
    {
        public Guid EmailTemplateAttachedId { get; set; }
        public Guid EmailTemplateId { get; set; }
        public EmailTemplateEntity EmailTemplate { get; set; }
        public string FilePath { get; set; }
    }
}
