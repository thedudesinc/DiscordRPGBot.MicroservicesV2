using DiscordRPGBot.BusinessLogic.Entities;

namespace DiscordRPGBot.BusinessLogic.SeedDataClasses
{
    public partial class SeedData
    {
        public readonly Location[] locations = new[]
        {
            new Location
            {
                Id = 1,
                Name = "Faelin",
                Description = "A small, simple town located on the outskirts of Neverwood forest. The people are kind and the food is good. It is an agricultural town that sources most of their income from the sale of wheat, beer, and barley.",
                IsHostile = false
            },
            new Location
            {
                Id = 2,
                Name = "Redkeep Tavern",
                Description = "A quiet tavern in the center of town. Only a few townfolk are present right now. Most of them look in your direction as you enter.",
                IsHostile = false
            },
            new Location
            {
                Id = 3,
                Name = "Faelin Sawmill",
                Description = "You smell a rich cedar as you enter the foreman's building. You are greeted by a burly human with a long shaggy beard.",
                IsHostile = false
            }
        };
    }
}
