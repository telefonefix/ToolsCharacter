using Data.Entities.Person;
using Data.Entities.Places;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities.Attribute
{
    [Table("AttributeKnowledgeAreas")]
    public class AttributeKnowledgeArea : IAttribute<AttributeKnowledgeArea>
    {
        [Key, Column(Order = 0)]
        public int IdCharactere { get; set; }
        [Key, Column(Order = 1)]
        public int Id  { get; set; }
        public int Value  { get; set; }
        public int Factor  { get; set; }
        public int Acquired  { get; set; }

        public virtual Character Character { get; set; }
        public virtual Area Area { get; set; }


    }
}
