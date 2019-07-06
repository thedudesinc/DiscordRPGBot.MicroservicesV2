namespace DiscordRPGBot.BusinessLogic.Models.Request
{
    public class PlayerCharacterCreateRequest
    {
        public string DiscordId { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public string Race { get; set; }
    }
}
