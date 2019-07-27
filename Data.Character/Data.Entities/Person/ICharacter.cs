using Data.Entities.Characterize;
using Data.Entities.Corporation;
using System.Collections.Generic;

namespace Data.Entities.Person
{

    public interface ICharacter
    {

        string FirstName { get; set; }

        string LastName { get; set; }

        Features[] Features { get; set; }

        List<Skills> Skills { get; set; }

        List<SpecialAbilities> SpecialAbilities { get; set; }

        ICorporation Corpo { get; set; }

        void CreateCharacter(
            string firstName,
            string lastName,
            IDictionary<string, int> features,
            IDictionary<string,int> skills,
            IDictionary<string, int> specials,
            IDictionary<string, int> resources,
            IEnumerable<string> patents
            );
    }

}
