using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities.Places
{
    [Table("Cities")]
    public class City : IPlace
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Area> Areas { get; set; }

    }
}
