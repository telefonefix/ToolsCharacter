using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Entities.Attribute;
using Data.Entities.Person;

namespace Data.Entities.Characterize
{
    [Table("Features")]
    public class Feature : ICharacteristic<Feature>
    {
        /// <summary>
        /// Columns
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// Relationships
        /// </summary>
        public ICollection<AttributeFeature> AttributeFeatures { get; set; }
        public ICollection<Skill> Skills { get; set; }
    }

    public enum EnumFeatures
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
