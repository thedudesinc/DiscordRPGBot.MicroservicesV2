﻿namespace DiscordRPGBot.BusinessLogic.Models.Response
{
    public class PlayerCharacterGetResponse
    {
        public string Name { get; set; }
        public string ProfileImageUrl { get; set; }
        public string ClassImageUrl { get; set; }
        public long CurrentXP { get; set; }
        public int CurrentLevel { get; set; }
        public int CurrentHP { get; set; }
        public int MaxHP { get; set; }
        public long Gold { get; set; }
        public string Class { get; set; }
        public string Race { get; set; }
        public int TotalStrongMod { get; set; }
        public int TotalFastMod { get; set; }
        public int TotalSmartMod { get; set; }
        public int TotalToughMod { get; set; }
    }
}
