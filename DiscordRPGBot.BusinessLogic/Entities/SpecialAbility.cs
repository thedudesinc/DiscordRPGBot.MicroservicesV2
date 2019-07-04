namespace DiscordRPGBot.BusinessLogic.Entities
{
    public class SpecialAbility
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsRPAbility { get; set; }
        public bool IsCombatAbility { get; set; }
    }
}
