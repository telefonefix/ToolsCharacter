using Data.Entities.Attribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities.Places
{
    [Table("Areas")]
    public class Area : IPlace
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public int IdCity  {get; set;}

        public virtual City City { get; set; }
        public ICollection<AttributeKnowledgeArea> AttributeKnowledgeArea { get; set; }

    }
}
