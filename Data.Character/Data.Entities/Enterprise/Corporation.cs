using Data.Entities.Person;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities.Enterprise
{
    [Table("Corporations")]
    public class Corporation : ICorporation
    {
        [Key]
        public int IdCorporation { get; set; }

        public IGrade Grade { get; set; }
        

        #region Properties
        public string Name { get; set; }


        public ICollection<Character> Characters { get; set; }
        public bool IsGang { get; set; }
        public string Color { get; set; }
        #endregion Properties

    }
}
