using DiscordRPGBot.BusinessLogic.Enums;
using System.Collections.Generic;

namespace DiscordRPGBot.BusinessLogic.Entities
{
    public class Action
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string SuccessMessage { get; set; }
        public ActionType Type { get; set; }
        public virtual ICollection<LocationAction> Locations { get; set; }
        public virtual ICollection<ClassAction> Classes { get; set; }
        public virtual ICollection<ItemAction> Items { get; set; }
        public virtual ICollection<RaceAction> Races { get; set; }
    }
}
