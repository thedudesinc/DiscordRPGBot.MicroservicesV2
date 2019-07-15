using DiscordRPGBot.BusinessLogic.Entities;
using DiscordRPGBot.BusinessLogic.Enums;

namespace DiscordRPGBot.BusinessLogic.SeedDataClasses
{
    public partial class SeedData
    {
        public readonly ItemAction[] itemActions = new[]
        {
            new ItemAction
            {
                Id = 1,
                Description = "drink minor healing potion",
                Effect = EffectType.Heal,
                Value = 10,
                ItemId = 1
            }
        };
    }
}
