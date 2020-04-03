using Data.Entities.Characterize;
using Data.Entities.Corporation;
using Data.Entities.Patent;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.Person
{
    public enum Gender
    {
        Male,
        Female,
        CyberRobot
    }
    [Table("Character")]
    public class Character : ICharacter
    {
        #region Attributs
        private ICharacteristic<Feature> _feature;
        private ICharacteristic<Skill> _skill;
        private ICharacteristic<SpecialAbility> _special;
        private IPatent _patent;
        private IEthnic _ethnie;
        private ICorporation _corporation;
        #endregion

        #region Properties
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Pseudo { get; set; }
        public Gender Gender { get; set; }
        public virtual Ethnic Ethnic { get; set; }        
        public List<Skill> Skills { get; set; }
        public List<SpecialAbility> SpecialAbilities { get; set; }
        public List<Resource> Resources { get; set; }
        public List<IPatent> Patents { get; set; }
        public int Chance { get; set; }

        public ICorporation Corpo { get; set; }
        public bool Alive { get; set; }
        public virtual ICollection<Feature> Features { get; set; }

        #endregion

        #region Constructor
        public Character(
            ICharacteristic<Feature> feature,
            ICharacteristic<Skill> skill,
            IEthnic ethnic)
        {
            this._feature = feature ?? throw new ArgumentNullException(nameof(feature));
            this._skill = skill ?? throw new ArgumentNullException(nameof(skill));
            this._ethnie = ethnic ?? throw new ArgumentNullException(nameof(ethnic));
        }
        #endregion
    }
}
