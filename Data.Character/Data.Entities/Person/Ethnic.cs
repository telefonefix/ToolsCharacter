using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities.Person
{
    [Table("Ethnic")]
    public class Ethnic : IEthnic
    {
        [Key]
        public int IdEthnie {get;set;}

        public string Name { get; set; }

        public string Description { get; set; }
        public virtual ICollection<Character> Characters { get; set; }

    }

    public enum EthnicList
    {
        American_English,
        African,
        Japanese_Korean,
        Central_European,
        Pacific_Island,
        Chinese,
        Black_American,
        Spanish_American,
        South_American,
        European
    }
}
