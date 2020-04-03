using Data.Entities.Characterize;
using Data.Entities.Corporation;
using Data.Entities.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class CharacterRepository : ICharacterRepository
    {
        void ICharacterRepository.Create(string firstName, string lastName, Gender gender)
        {
            throw new NotImplementedException();
        }

        void ICharacterRepository.Update()
        {
            throw new NotImplementedException();
        }
    }
}
