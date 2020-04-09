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
        int IdCorporation { get; set; }
        string Name { get; set; }

        bool IsGang { get; set; }

        string Color { get; set; }

        /// <summary>
        /// Relationships
        /// </summary>
        ICollection<Character> Characters { get; set; }
    }
}
