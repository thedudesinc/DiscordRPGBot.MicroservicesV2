using System;

namespace DiscordRPGBot.BusinessLogic.Entities
{
    public class Inventory
    {
        public long PlayerCharacterId { get; set; }
        public virtual PlayerCharacter PlayerCharacter { get; set; }
        public long ItemId { get; set; }
        public virtual Item Item { get; set; }
        public int Quantity { get; set; }
        public DateTimeOffset CreatedOn { get; set; } = DateTimeOffset.Now;
    }
}
