using DiscordRPGBot.BusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiscordRPGBot.BusinessLogic.Entities
{
    public class Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long Value { get; set; }
        public ItemType Type { get; set; }
        public ItemRarity Rarity { get; set; }
        public virtual ICollection<Inventory> PlayerCharacters { get; set; }
        public virtual ICollection<ItemAction> Actions { get; set; }
    }
}
