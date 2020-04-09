using Data.Entities.Attribute;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Characterize
{
    public class Resource : ICharacteristic<Resource>
    {
        /// <summary>
        /// Columns
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// Relationships
        /// </summary>
        public ICollection<AttributeResource> AttributeResources { get; set; }
    }
}
