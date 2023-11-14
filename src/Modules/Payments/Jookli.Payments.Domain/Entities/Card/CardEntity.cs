using Jookli.BuildingBlocks.Domain;
using Jookli.Payments.Domain.Entities.User;
using Jookli.Payments.Domain.Interfaces;

namespace Jookli.Payments.Domain.Entities.Card
{
    public class CardEntity : Entity, IHasId, IHasObject
    {
        public Guid CardId { get; set; }
        public string Id { get; set; }
        public string Object { get; set; }
        public string AddressCity { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine1Check { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine2Check { get; set; }
        public string AddressState { get; set; }
        public string AddressZip { get; set; }
        public string AddressZipCheck { get; set; }
        //public List<string> AvailablePayoutMethods { get; set; }
        public string Brand { get; set; }
        public string Country { get; set; }
        public string Currency { get; set; }
        public string CvcCheck { get; set; }
        public bool? DefaultForCurrency { get; set; }
        public bool? IsDeleted { get; set; }
        public string Description { get; set; }
        /// <summary>
        /// (For tokenized numbers only.) The last four digits of the device account number.
        /// </summary>
        public string DynamicLast4 { get; set; }
        /// <summary>
        /// The last four digits of the card.
        /// </summary>
        public string Last4 { get; set; }
        public string Fingerprint { get; set; }
        public string Funding { get; set; }
        public long ExpYear { get; set; }
        /// <summary>
        /// Issuer identification number of the card.
        /// </summary>
        public string Iin { get; set; }
        /// <summary>
        /// The name of the card's issuing bank.
        /// </summary>
        public string Issuer { get; set; }
        /// <summary>
        /// Cardholder name.
        /// </summary>
        public string Name { get; set; }
        public string TokenizationMethod { get; set; }
        public string Status { get; set; }
        //public Dictionary<string, string> Metadata { get; set; }
        public ICollection<UserEntity> Users { get; set; }

    }
}
