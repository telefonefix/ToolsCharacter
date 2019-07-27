using Autofac;
using Data.Entities.Characterize;
using Data.Entities.Corporation;
using Data.Entities.Person;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Factories
{
    public enum FieldsList
    {
        Carac,
        Capac,
        Comp,
        Res,
        Cyber
    }

    public class Factory : IFactory
    {
        #region Attributs
        private IContainer _container;
        private ICharacter _character;
        private IEnumerable<FeaturesList> _features;
        private IEnumerable<SpecialAbilitiesList> _specials;        
        #endregion
        #region Properties
        public IDictionary<string, int> Features { get; set; }
        public IDictionary<string, int> Skills { get; set; }
        public IDictionary<string, int> SpecialAbilities { get; set; }
        public IDictionary<string, int> Resources { get; set; }
        public List<string> Patents { get; set; }
        #endregion
        #region Constructor
        public Factory()
        {
            Init();
            BuildDependency();
        }
        #endregion

        private void BuildDependency()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Character>().As<ICharacter>();
            builder.RegisterType<Skills>().As<IRepository<Skills>>();
            builder.RegisterType<Features>().As<IRepository<Features>>();
            builder.RegisterType<SpecialAbilities>().As<IRepository<SpecialAbilities>>();
            builder.RegisterType<Resources>().As<IRepository<Resources>>();
            builder.RegisterType<Corporation>().As<ICorporation>();
            builder.RegisterType<Grade>().As<IGrade>();
            builder.RegisterType<Patents>().As<IPatents>();

            _container = builder.Build();
        }



        private void Init()
        {
            Features = new Dictionary<string, int>();
            Skills = new Dictionary<string, int>();
            SpecialAbilities = new Dictionary<string, int>();

            _features = Enum.GetValues(typeof(FeaturesList)).Cast<FeaturesList>();
            _specials = Enum.GetValues(typeof(SpecialAbilitiesList)).Cast<SpecialAbilitiesList>();
        }

        

        public void CreateCharacter(string firsName, string lastName)
        {
            using (var scope = _container.BeginLifetimeScope())
            {
                _character = scope.Resolve<ICharacter>();
                _character.CreateCharacter(firsName, lastName, Features, Skills,SpecialAbilities,Resources,Patents);
            }
        }

        public List<string> GetEnumList<T>(T t)
        {
            List<string> list = new List<string>();
            
            IEnumerable<T> enumItem = Enum.GetValues(typeof(T)).Cast<T>();

            foreach (var e in enumItem)
            {
                list.Add(e.ToString().ToLower());
            }
            return list;
        }        

        public void CreateCorporation(string name, Grade grade)
        {
            using (var scope = _container.BeginLifetimeScope())
            {
                var corpo = scope.Resolve<ICorporation>();
                corpo.CreateCorporation(name, grade);
            }
        }

        public void CreateCorporation(string name, string grade)
        {
            int qty = grade.Length;
            Category category;
            switch (grade.Substring(0, 1))
            {
                case "o":
                    category = Category.Circle;
                    break;
                case "^":
                    category = Category.Triangle;
                    break;
                case "*":
                    category = Category.Star;
                    break;
                default:
                    category = Category.Circle;
                    break;
            }


            using (var scope = _container.BeginLifetimeScope())
            {
                var corpo = scope.Resolve<ICorporation>();
                corpo.CreateCorporation(name, category, qty);
            }
        }

        public void CreateCorporation(string name, Category category, int qty)
        {

            using (var scope = _container.BeginLifetimeScope())
            {
                var corpo = scope.Resolve<ICorporation>();
                corpo.CreateCorporation(name, category, qty);
            }
        }

        public List<string> GetFeatureList()
        {
            List<string> features = new List<string>();
            IEnumerable<FeaturesList> feat = Enum.GetValues(typeof(FeaturesList)).Cast<FeaturesList>();

            foreach (var f in feat)
            {
                features.Add(f.ToString());
            }
            return features;
        }
    }
}
