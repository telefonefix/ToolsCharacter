using Data.Entities.Attribute;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Characterize
{
    [Table("Skills")]
    public class Skill : ICharacteristic<Skill>
    {
        /// <summary>
        /// Columns
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }        
        public int IdFeature { get; set; }

        /// <summary>
        /// Relationships
        /// </summary>
        public virtual Feature Feature { get; set; }
        public ICollection<AttributeSkill> AttributeSkills { get; set; }

    }
}
