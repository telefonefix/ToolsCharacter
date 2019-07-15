using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using Data.Entities.Person;
using Data.Entities.Characterize;
using Data.Entities.Corporation;

namespace Data.Factories
{
    public class Factory : IFactory
    {
        private IContainer _container { get; set; }

        public Factory()
        {
            BuildDependency();
        }

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
            _container = builder.Build();            


        }

        public void CreateCharacter(string firsName,string lastName)
        {
            using (var scope = _container.BeginLifetimeScope())
            {
                var character = scope.Resolve<ICharacter>();
                character.CreateCharacter(firsName,lastName);
            }
        }

        public void CreateCorporation(string name,Grade grade)
        {
            using (var scope = _container.BeginLifetimeScope())
            {
                var corpo = scope.Resolve<ICorporation>();
                corpo.CreateCorporation(name, grade);
            }
        }

        public void CreateCorporation(string name, Category category,int qty)
        {
            using (var scope = _container.BeginLifetimeScope())
            {
                var corpo = scope.Resolve<ICorporation>();
                corpo.CreateCorporation(name, category, qty);
            }
        }
    }
}
