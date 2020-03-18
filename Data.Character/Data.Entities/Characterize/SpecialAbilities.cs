namespace Data.Entities.Characterize
{

    public enum SpecialAbilitiesList
    {
        Sens_du_combat,
        Furtif,        
        Interface,
        Autorite,
        Charisme,
        Persuaders,
        Fixer,
        Techmed,
        Media,
        Techi
    }

    public class SpecialAbilities : IRepository<SpecialAbilities>
    {
        public string Name { get; set; }
        public int Value { get; set; }
        public int Id { get;}
    }
}
