using DiscordRPGBot.BusinessLogic.Enums;
using System;
using System.Collections.Generic;

namespace DiscordRPGBot.BusinessLogic.Entities
{
    public class Item
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long Value { get; set; }
        public ItemType Type { get; set; }
        public ItemRarity Rarity { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset UpdatedOn { get; set; }

        public virtual ICollection<PlayerCharacter> PlayerCharacters { get; set; }
    }
}
