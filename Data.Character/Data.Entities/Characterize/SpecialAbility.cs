namespace Data.Entities.Characterize
{
    public class SpecialAbility : ICharacteristic<SpecialAbility>
    {
        public string Name { get; set; }
        public int Value { get; set; }
        public int Id { get; set; }
    }
}
