using DiscordRPGBot.BusinessLogic.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiscordRPGBot.BusinessLogic.Entities
{
    public class ItemAction
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public string SuccessMessageTemplate { get; set; }
        public string FailureMessageTemplate { get; set; }
        public EffectType Effect { get; set; }
        public int Value { get; set; }
        public long ItemId { get; set; }
        public virtual Item Item { get; set; }
    }
}
