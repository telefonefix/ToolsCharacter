﻿using Data.Entities.Characterize;
using Data.Entities.Enterprise;
using Data.Entities.Person;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities.Attribute
{
    [Table("AttributeResources")]

    public class AttributeResource : IAttribute<AttributeResource>
    {
        [Key, Column(Order = 0)]
        public int IdCharactere { get; set; }
        [Key, Column(Order = 1)]
        public int Id { get; set; }
        public int Value { get; set; }

        //  The below properties will always be the same value 
        //  Multiplier = 1 and Acquired = 0
        public int Multiplier { get; set; }
        public int Acquired { get; set; }

        public virtual Character Character { get; set; }
        
        public virtual Corporation Corporation { get; set; }

    }
}
