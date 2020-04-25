﻿using Data.Entities.Attribute;
using Data.Entities.Person;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities.Characterize
{
    [Table("Protections")]
    public class Protection : ICharacteristic<Protection>
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
        public ICollection<AttributeProtection> AttributeProtection { get; set; }
    }

    public enum EnumProtection
    {
        Head,
        Body,
        Leg,
        Feet,
        Arm,
        Hand        
    }
}
