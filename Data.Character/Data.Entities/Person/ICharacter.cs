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
    }

}
