using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Corporation
{


    [Table("Grade")]
    public class Grade : IGrade
    {
        [Key]
        public int Id { get; set; }
        public EnumCategory Category { get; set; }

        public int Qty { get; set; }

        public string Rank { get; set; }

    }
}
