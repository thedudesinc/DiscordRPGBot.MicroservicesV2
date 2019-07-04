using System;

namespace DiscordRPGBot.BusinessLogic.Entities
{
    public class Inventory
    {
        public long Id { get; set; }
        public long PlayerCharacterId { get; set; }
        public long ItemId { get; set; }
        public DateTimeOffset CreatedOn { get; set; }

        public virtual PlayerCharacter PlayerCharacter { get; set; }
        public virtual Item Item { get; set; }
    }
}
