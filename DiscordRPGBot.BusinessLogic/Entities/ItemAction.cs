using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordRPGBot.BusinessLogic.Entities
{
    public class ItemAction
    {
        public long ItemId { get; set; }
        public Item Item { get; set; }
        public long ActionId { get; set; }
        public Action Action { get; set; }
    }
}
