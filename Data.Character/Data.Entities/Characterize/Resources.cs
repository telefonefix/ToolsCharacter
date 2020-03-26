namespace Data.Entities.Characterize
{
    public class Ressources : IRepository<Ressources>
    {
        public string Name { get; set; }
        public int Value { get; set; }
        public int Id { get; set; }
    }
}
