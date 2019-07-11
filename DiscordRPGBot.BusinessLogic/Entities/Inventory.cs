using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiscordRPGBot.BusinessLogic.Entities
{
    public class Inventory
    {
        public int Quantity { get; set; }
        public long PlayerCharacterId { get; set; }
        public long ItemId { get; set; }
        public DateTimeOffset CreatedOn { get; set; } = DateTimeOffset.Now;
        public virtual PlayerCharacter PlayerCharacter { get; set; }
        public virtual Item Item { get; set; }
    }
}
