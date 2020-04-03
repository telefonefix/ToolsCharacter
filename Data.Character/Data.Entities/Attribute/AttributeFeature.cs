﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities.Attribute
{
    public class AttributeFeature : IAttribute<AttributeFeature>
    {
        public int IdCharactere { get; set; }
        public int IdFeature { get; set; }
        public int Value { get; set; }

        //  The below properties will always be the same value 
        //  Multiplier = 1 and Acquired = 0
        public int Multiplier { get; set; }
        public int Acquired { get; set; }
    }
}
