using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities.Attribute
{
    public class AttributeSkill : IAttribute<AttributeSkill>
    {
        public int IdCharactere { get; set; }
        public int IdSkill { get; set; }
        public int Value { get; set; }
        public int Multiplier { get; set; }
        public int Acquired { get; set; }
    }
}
