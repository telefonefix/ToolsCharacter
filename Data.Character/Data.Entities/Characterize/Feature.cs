using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Entities.Person;

namespace Data.Entities.Characterize
{
    [Table("Features")]
    public class Feature : ICharacteristic<Feature>
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }


        public int Value { get; set; }
        public ICollection<Character> Characters { get; set; }
    }

    public enum FeaturesList
    {
        BT = 0,
        CON = 1,
        EMP = 2,
        MVT = 3,
        SF = 4,
        TECH = 5,
        INT = 6,
        REF = 7
    }
}
