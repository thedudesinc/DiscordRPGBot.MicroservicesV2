namespace DiscordRPGBot.BusinessLogic.Entities
{
    public class LocationAction
    {
        public long LocationId { get; set; }
        public Location Location { get; set; }
        public long ActionId { get; set; }
        public Action Action { get; set; }
    }
}
