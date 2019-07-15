using DiscordRPGBot.BusinessLogic.Entities;
using DiscordRPGBot.BusinessLogic.Enums;

namespace DiscordRPGBot.BusinessLogic.SeedDataClasses
{
    public partial class SeedData
    {
        public readonly Item[] items = new[]
        {
            new Item
            {
                Id = 1,
                Name = "Minor Healing Potion",
                Description = "Heals you 10 points.",
                Rarity = ItemRarity.Common,
                Type = Enums.ItemType.Miscellaneous,
                Value = 10
            }
        };
    }
}
