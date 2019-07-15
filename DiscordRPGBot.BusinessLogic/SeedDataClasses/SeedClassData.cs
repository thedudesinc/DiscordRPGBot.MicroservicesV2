using DiscordRPGBot.BusinessLogic.Entities;

namespace DiscordRPGBot.BusinessLogic.SeedDataClasses
{
    public partial class SeedData
    {
        public readonly Class[] classes = new[]
        {
            new Class {
                Id = 1,
                Name = "Fighter",
                Description = "Melee build. Can only use STR weapons.",
                ImageUrl = "https://i.imgur.com/Bcv0Y2s.png",
                StrongMod = 4,
                FastMod = 1,
                SmartMod = 1,
                ToughMod = 4
            },
            new Class
            {
                Id = 2,
                Name = "Rogue",
                Description = "Melee or Ranged build. Can only use DEX weapons.",
                ImageUrl = "https://i.imgur.com/VCfFj8K.png",
                StrongMod = 1,
                FastMod = 4,
                SmartMod = 4,
                ToughMod = 1
            },
            new Class
            {
                Id = 3,
                Name = "Ranger",
                Description = "Melee or Ranged build. Can use DEX or STR weapons.",
                ImageUrl = "https://i.imgur.com/dxUnMPG.png",
                StrongMod = 3,
                FastMod = 3,
                SmartMod = 2,
                ToughMod = 2
            },
            new Class
            {
                Id = 4,
                Name = "Wizard",
                Description = "Magic build. Can only use spells.",
                ImageUrl = "https://i.imgur.com/8U6oW2H.png",
                StrongMod = 1,
                FastMod = 2,
                SmartMod = 6,
                ToughMod = 1
            },
        };
    }
}
