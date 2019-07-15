using Data.Entities.Characterize;
using Data.Entities.Corporation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Data.Entities.Person
{
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

        public Features[] Features { get; set; }

        public List<Skills> Skills { get; set; }

        public List<SpecialAbilities> SpecialAbilities { get; set; }

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
            //this._corporation = CheckCorpo(corporation);
            this._corporation = corporation ?? throw new ArgumentNullException(nameof(corporation));
        }
        #endregion

        #region Public Methods
        public void CreateCharacter()
        {
            //FirstName = "John";
            //LastName = "Doe";

            //SetFeature();
        }

        #endregion

        #region Private Methods
        private void SetFeature()
        {
            Features = new Features[Enum.GetValues(typeof(FeaturesList)).Length];

            IEnumerable<FeaturesList> feat = Enum.GetValues(typeof(FeaturesList)).Cast<FeaturesList>();
            int i = 0;
            foreach (var f in feat)
            {
                _feature.Name = f.ToString();
                _feature.Value = 0;
                Features.SetValue(_feature, i);
                i++;
            }

        }

        // Pas mettre ici
        //public void SetPerson(string name)
        //{
        //    char[] none = { '(', ')' };

        //    if (name.Contains("("))
        //    {
        //        string corpo = name.Substring(name.IndexOf("("));
        //        string tmp = corpo.Replace(" ", string.Empty);
        //        name = name.Replace(corpo, tmp);

        //    }

        //    string[] n = name.Split(' ');




        //    if (n.Length > 2)
        //    {
        //        FirstName = n[0];
        //        LastName = n[1];
        //    }
        //    else
        //    {
        //        LastName = n[0];
        //        FirstName = string.Empty;
        //    }

        //    // Personne travaille pour une corpo
        //    if (n[n.Length - 1].Contains("("))
        //    {
        //        n[n.Length - 1] = n[n.Length - 1].Trim(none);
        //        ManageCorpo(n[n.Length - 1]);
        //    }
        //}
        // TODO: Renommer la méthode
        private void ManageCorpo(string corpo)
        {
            corpo = corpo.Trim();

            string grade = corpo.Substring(0, 1).Trim();

            switch (grade)
            {
                case "^":
                    Corpo.Grade.Category = Category.Triangle;
                    break;
                case "*":
                    Corpo.Grade.Category = Category.Star;
                    break;
                default:
                    Corpo.Grade.Category = Category.Circle;
                    break;
            }
            char[] g = grade.ToCharArray();

            Corpo.Grade.Qty = corpo.Split(g[0]).Length - 1;

            Corpo.Name = corpo.Substring(corpo.IndexOf(' '));
        }
        private ICorporation CheckCorpo(ICorporation corpo)
        {
            string[] noCorpo = { "freelance", "none", "n/a", string.Empty };

            if (corpo.Name == null)
            {
                corpo.Name = "freelance";
            }

            foreach (var no in noCorpo)
            {
                if (Array.Exists(noCorpo, a => Regex.IsMatch(corpo.Name, no.ToString(), RegexOptions.IgnoreCase)))
                {
                    corpo.Name = "Freelance";
                    corpo.Grade = new Grade()
                    {
                        Category = Category.Star,
                        Qty = 5
                    };
                }
            }

            return corpo;
        }

        public void CreateCharacter(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        #endregion
    }
}
