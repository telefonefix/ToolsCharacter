using Data.Entities.Person;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Enterprise
{


    [Table("Grades")]
    public class Grade : IGrade
    {
        /// <summary>
        /// Columns
        /// </summary>
        [Key]
        public int Id { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }
        public int Ressource { get; set; }
        public int Salary { get; set; }
        /// <summary>
        /// Relationships
        /// </summary>
        public ICollection<Character> Characters { get; set; }

    }
}
