using Data.Entities.Characterize;
using Data.Entities.Person;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities.Attribute
{
    [Table("AttributeProtections")]
    public class AttributeProtection : IAttribute<AttributeProtection>
    {
        [Key, Column(Order = 0)]
        public int IdCharactere { get; set; }
        [Key, Column(Order = 1)]
        public int Id { get; set; }
        public int Value { get; set; }
        public int Multiplier { get; set; }
        public int Acquired { get; set; }

        public virtual Character Character { get; set; }

        public virtual Protection Protection { get; set; }
    }
}
