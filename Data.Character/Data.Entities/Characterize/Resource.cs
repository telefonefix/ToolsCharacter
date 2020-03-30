namespace Data.Entities.Characterize
{
    public class Resource : ICharacteristic<Resource>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
    }
}
