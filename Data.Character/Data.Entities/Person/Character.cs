using Data.Entities.Characterize;
using Data.Entities.Corporation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Data.Entities.Person
{
    public enum Gender
    {
        Male,
        Female,
        CyberRobot
    }

    public class Character : ICharacter
    {
        #region Attributs
        private IRepository<Features> _feature;
        private IRepository<Skills> _skill;
        private IRepository<SpecialAbilities> _special;

        private ICorporation _corporation;
        #endregion

        #region Properties
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Pseudo { get; set; }
        public Gender Gender { get; set; }
        public Features[] Features { get; set; }
        public List<Skills> Skills { get; set; }
        public List<SpecialAbilities> SpecialAbilities { get; set; }
        public List<Ressources> Resources { get; set; }
        public List<Patents> Patents { get; set; }

        public ICorporation Corpo { get; set; }

        public int Chance { get; set; }
        #endregion

        #region Constructor
        public Character(
            IRepository<Features> feature,
            IRepository<Skills> skill,
            IRepository<SpecialAbilities> special,
            ICorporation corporation)
        {
            this._feature = feature ?? throw new ArgumentNullException(nameof(feature));
            this._skill = skill ?? throw new ArgumentNullException(nameof(skill));
            this._special = special ?? throw new ArgumentNullException(nameof(special));
            this._corporation = corporation ?? throw new ArgumentNullException(nameof(corporation));
        }
        #endregion
    }
}
