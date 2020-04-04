using Data.Entities.Person;

namespace Data.Repositories
{
    public class CharacterRepository : ICharacterRepository
    {
        private DbCharacterRepository _dbRepository;

        public CharacterRepository()
        {
            _dbRepository = new DbCharacterRepository();
        }

        public CharacterRepository(DbCharacterRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }

        public void Create(string firstName, string lastName, string pseudo, EnumGender gender)
        {
            // TODO : Voir plus tard pour IdEthnic
            _dbRepository.Add(new Character()
            {
                FirstName = firstName,
                LastName = lastName,
                Pseudo = pseudo,
                Gender = gender,
                IdEthnic = 1,
                Alive = true
            });
        }
        public void Update() { }
    }
}
