namespace DiscordRPGBot.BusinessLogic.Entities
{
    public class ClassAction
    {
        public long ClassId { get; set; }
        public Class Class { get; set; }
        public long ActionId { get; set; }
        public Action Action { get; set; }
    }
}
