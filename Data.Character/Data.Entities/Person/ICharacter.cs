using Data.Entities.Attribute;
using Data.Entities.Enterprise;
using System.Collections.Generic;

namespace Data.Entities.Person
{

    public interface ICharacter
    {
        int Id { get; set; }
        string FirstName { get; set; }

        string LastName { get; set; }

        EnumGender Gender { get; set; }

        bool Alive { get; set; }

        ICollection<AttributeFeature> AttributeFeatures { get; set; }
        ICollection<AttributeSpecialAbility> AttributeSpecialAbilities { get; set; }

        

        Corporation Corporation { get; set; }

        Ethnic Ethnic { get; set; }
    }

}
