namespace Data.Entities.Characterize
{
    public class Resources : IRepository<Resources>
    {
        public string Name { get; set; }
        public int Value { get; set; }
        public int Id { get; }
    }
}
