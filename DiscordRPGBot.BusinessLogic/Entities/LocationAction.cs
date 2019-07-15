using DiscordRPGBot.BusinessLogic.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiscordRPGBot.BusinessLogic.Entities
{
    public class LocationAction
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public string SuccessMessageTemplate { get; set; }
        public string FailureMessageTemplate { get; set; }
        public long? RelocateToId { get; set; }
        public int? Amount { get; set; }
        public TransactionType? TransactionType { get; set; }
        public virtual Location Location { get; set; }
        public long LocationId { get; set; }
    }
}
