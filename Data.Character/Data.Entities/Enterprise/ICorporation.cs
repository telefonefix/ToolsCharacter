using Data.Entities.Attribute;
using Data.Entities.Person;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Entities.Enterprise
{

    public interface ICorporation
    {
        /// <summary>
        /// Columns
        /// </summary>
        [Key]
        int Id { get; set; }
        string Name { get; set; }

        bool IsGang { get; set; }

        string Color { get; set; }

        /// <summary>
        /// Relationships
        /// </summary>
        ICollection<Character> Characters { get; set; }

        ICollection<AttributeResource> AttributeResources { get; set; }

    }
}
