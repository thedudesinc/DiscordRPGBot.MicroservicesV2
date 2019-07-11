using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordRPGBot.BusinessLogic.Entities
{
    public class RaceAction
    {

        public long RaceId { get; set; }
        public Race Race { get; set; }
        public long ActionId { get; set; }
        public Action Action { get; set; }

    }
}
