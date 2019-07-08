using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordRPGBot.BusinessLogic.Models.Request
{
    public class PlayerCharacterSetImageRequest
    {
        public string DiscordId { get; set; }
        public string ImageUrl { get; set; }
    }
}
