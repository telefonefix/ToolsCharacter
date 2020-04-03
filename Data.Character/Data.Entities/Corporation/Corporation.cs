using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities.Corporation
{
    [Table("Corporation")]
    public class Corporation : ICorporation
    {
        #region Attributs
        private IGrade _grade;
        [Key]
        public int Id { get; set; }

        public IGrade Grade {
            get
            {
                return _grade;
            }
            set
            {
                _grade = value;
            }
        }
        #endregion Attributs

        #region Properties
        public string Name { get; set; }

        public Corporation(IGrade grade)
        {
            _grade = grade;
        }
        #endregion Properties
      
    }
}
