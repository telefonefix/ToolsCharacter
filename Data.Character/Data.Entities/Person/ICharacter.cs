using Data.Entities.Characterize;
using Data.Entities.Corporation;
using System.Collections.Generic;

namespace Data.Entities.Person
{

    public interface ICharacter
    {

        string FirstName { get; set; }

        string LastName { get; set; }

        Gender Gender { get; set; }

        bool Alive { get; set; }

        IEthnie Ethnie { get; set; }

        Feature[] Features { get; set; }

        List<Skill> Skills { get; set; }

        List<SpecialAbility> SpecialAbilities { get; set; }

        ICorporation Corpo { get; set; }
    }

}
