using Data.Entities.Attribute;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities.Characterize
{
    public class Protection : ICharacteristic<Protection>
    {
        /// <summary>
        /// Columns
        /// </summary>
        public int Id { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// Relationships
        /// </summary>
        public ICollection<AttributeProtection> AttributeProtection { get; set; }

    }
}
