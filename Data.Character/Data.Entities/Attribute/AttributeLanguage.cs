namespace Data.Entities.Attribute
{
    public class AttributeLanguage : IAttribute<AttributeLanguage>
    {
        public int IdCharactere { get; set; }
        public int IdLanguage { get; set; }
        public int Value { get; set; }
        public int Multiplier { get; set; }
        public int Acquired { get; set; }
    }
}
