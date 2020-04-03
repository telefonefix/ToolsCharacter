using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities.Attribute
{
    public class AttributeSpecialAbility : IAttribute<AttributeSpecialAbility>
    {
        public int IdCharactere { get; set; }
        public int IdSpecialAbility { get; set; }
        public int Value { get; set; }
        public int Multiplier { get; set; }
        public int Acquired { get; set; }
    }
}
