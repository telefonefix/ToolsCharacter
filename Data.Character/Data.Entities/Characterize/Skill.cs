namespace Data.Entities.Characterize
{
    public class Skill : ICharacteristic<Skill>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
        public int IdFeatures { get; set; }
        public int AcquiredPoint { get; set; }
    }
}
