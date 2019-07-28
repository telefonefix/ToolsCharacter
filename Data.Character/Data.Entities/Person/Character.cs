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
        public List<Resources> Resources { get; set; }
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
            //this._corporation = CheckCorpo(corporation);
            this._corporation = corporation ?? throw new ArgumentNullException(nameof(corporation));

            Init();
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

        private void Init()
        {
            Features = new Features[Enum.GetValues(typeof(FeaturesList)).Length];
            Skills = new List<Skills>();
            SpecialAbilities = new List<SpecialAbilities>();
        }

        private void SetFeature()
        {

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


        private void GetFeatures(IDictionary<string, int> features)
        {   
            List<Features> featureList = new List<Features>();

            foreach (var f in features)
            {
                Features feature = new Features();
                feature.Name = f.Key;
                feature.Value = f.Value;

                featureList.Add(feature);
            }
            Features = featureList.ToArray();
        }

        private void GetCharacterize<T>(T t,Dictionary<string,int> dictionary)
        {
            List<T> characterizeList = new List<T>();

            foreach (var d in dictionary)
            {   
                // = d.Key;
                //t = d.Value;

                characterizeList.Add(t);
            }
            

            switch (t)
            {
                case Features f:
                    //Features = characterizeList.ToArray();
                    break;
                case Skills s:
                    break;
                case SpecialAbilities s:
                    break;
                case Resources r:
                    break;
                case Patents p:
                    break;
                default:
                    break;
            }
        }

        public void CreateCharacter(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public void CreateCharacter(string firstName, string lastName, IDictionary<string, int> features)
        {
            FirstName = firstName;
            LastName = lastName;
            int i = 0;
            foreach (var f in features)
            {
                _feature = new Features();
                _feature.Name = f.Key;
                _feature.Value = f.Value;

                Features.SetValue(_feature, i);
                i++;
            }

        }

        public void CreateCharacter(string firstName, string lastName, IDictionary<string, int> features, IDictionary<string, int> skills, IDictionary<string, int> specials, IDictionary<string, int> resources, IEnumerable<string> patents)
        {
            FirstName = firstName;
            LastName = lastName;
            GetFeatures(features);

        }
        #endregion
    }
}
