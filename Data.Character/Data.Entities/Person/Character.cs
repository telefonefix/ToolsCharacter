using Data.Entities.Attribute;
using Data.Entities.Characterize;
using Data.Entities.Enterprise;
using Data.Entities.Patent;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Person
{
    public enum EnumGender
    {
        Male,
        Female,
        CyberRobot
    }
    [Table("Characters")]
    public class Character : ICharacter
    {
        #region Attributs
        //private ICharacteristic<Feature> _feature;
        //private ICharacteristic<Skill> _skill;
        //private ICharacteristic<SpecialAbility> _special;
        //private IPatent _patent;
        //private IEthnic _ethnie;
        //private ICorporation _corporation;
        #endregion
        /// <summary>
        /// Columns
        /// </summary>
        #region Properties
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Pseudo { get; set; }
        public EnumGender Gender { get; set; }        
        public int Chance { get; set; }
        public bool Alive { get; set; }


        public int? IdCorporation { get; set; }
        public int? IdGrade { get; set; }
        public int IdEthnic { get; set; }

        public virtual Ethnic Ethnic { get; set; }
        public virtual Corporation Corporation { get; set; }
        public virtual Grade Grade { get; set; }
        //public virtual ICollection<Feature> Features { get; set; }
        public ICollection<AttributeFeature> AttributeFeatures { get; set; }        
        public ICollection<AttributeSpecialAbility> AttributeSpecialAbilities { get; set; }
        public ICollection<AttributeSkill> AttributeSkills { get; set; }
        public ICollection<AttributeResource> AttributeResource { get; set; }

        #endregion

        #region Constructor
        //public Character(
        //    ICharacteristic<Feature> feature,
        //    ICharacteristic<Skill> skill,
        //    ICorporation corporation,
        //    IEthnic ethnic)
        //{
        //    _feature = feature ?? throw new ArgumentNullException(nameof(feature));
        //    _skill = skill ?? throw new ArgumentNullException(nameof(skill));
        //    _ethnie = ethnic ?? throw new ArgumentNullException(nameof(ethnic));
        //    _corporation = corporation ?? throw new ArgumentNullException(nameof(corporation));
        //}

        public Character()
        {
            //_feature = new Feature();
            //_special = new SpecialAbility();
            //_skill = new Skill();
            //_ethnie = new Ethnic();
        }
        #endregion
    }
}
