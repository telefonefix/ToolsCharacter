using Data.Entities.Characterize;
using Data.Entities.Person;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using AutoMapper.Configuration.Annotations;
using AutoMapper;

namespace Data.Entities.Attribute
{
    [Table("AttributeSkills")]
    [AutoMap(typeof(Skill))]
    public class AttributeSkill : IAttribute<AttributeSkill>
    {
        [Key, Column(Order = 0)]
        public int IdCharactere { get; set; }
        [Key, Column(Order = 1)]
        public int Id { get; set; }

        public int Value { get; set; }

        public int Factor { get; set; }

        public int Acquired { get; set; }


        public virtual Character Character { get; set; }

        public virtual Skill Skill { get; set; }
    }
}
