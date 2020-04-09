namespace Data.Context.Migrations
{
    using Data.Entities.Characterize;
    using Data.Entities.Enterprise;
    using Data.Entities.Person;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Data.Context.CharactereContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Data.Context.CharactereContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            SetFeature(context);
            SetEthnic(context);
            SetGrade(context);
        }
        private void SetFeature(CharactereContext context)
        {
            foreach (EnumFeatures feature in Enum.GetValues(typeof(EnumFeatures)).Cast<EnumFeatures>())
            {

                Feature feat = new Feature()
                {
                    Name = feature.ToString()
                };

                IQueryable<Feature> query = context.Features.Where(f => f.Name == feat.Name);
                if (query.Count() == 0)
                {
                    context.Features.AddOrUpdate(feat);
                }

            }
        }

        private void SetEthnic(CharactereContext context)
        {
            Dictionary<EnumEthnic, string> dic = new Dictionary<EnumEthnic, string>()
            {
                { EnumEthnic.American_English,"English" },
                { EnumEthnic.African,"Bantou,Fante,Congo,Ashanti,Zoulou,Swahili" },
                { EnumEthnic.Japanese_Korean,"Japanese,Korean" },
                { EnumEthnic.Central_European,"Bulgarian,Russian,Czech,Polish,Ukrainian,Slovak" },
                { EnumEthnic.Pacific_Island,"Micronesian,Tagalog,Polynesian,Malay,Indonesian,Hawaiian" },
                { EnumEthnic.Chinese,"Burmese,Cantonese,Tangerine,Thai,Tibetan,Vietnamese" },
                { EnumEthnic.Black_American,"English,Blackfolk" },
                { EnumEthnic.Spanish_American,"English,Spanish" },
                { EnumEthnic.South_American,"Spanish,Portuguese" },
                { EnumEthnic.European,"French,German,English,Spanish,Italian,Greek,Danish,Dutch,Swedish,Finnish,Portuguese" }
            };



            foreach (EnumEthnic ethnic in Enum.GetValues(typeof(EnumEthnic)).Cast<EnumEthnic>())
            {
                Ethnic eth = new Ethnic()
                {
                    Name = ethnic.ToString(),
                    Description = dic[ethnic]
                };

                IQueryable<Ethnic> query = context.Ethnics.Where(e => e.Name == eth.Name);
                if (query.Count() == 0)
                {
                    context.Ethnics.AddOrUpdate(eth);
                }
            }
        }

        private void SetGrade(CharactereContext context)
        {
            Dictionary<EnumCategory, char> dicoGrade = new Dictionary<EnumCategory, char>()
            {
                { EnumCategory.Circle,'\u25CF' },
                { EnumCategory.Triangle,'\u25BC' },
                { EnumCategory.Star, '\u2605' }
            };

            Dictionary<EnumCategory, int> dicoResource = new Dictionary<EnumCategory, int>()
            {
                { EnumCategory.Circle,1 },
                { EnumCategory.Triangle,4 },
                { EnumCategory.Star, 6 }
            };

            Dictionary<EnumCategory, int> dicoSalary = new Dictionary<EnumCategory, int>()
            {
                { EnumCategory.Circle,7000},
                { EnumCategory.Triangle,20000 },
                { EnumCategory.Star, 50000 }
            };

            foreach (var item in Enum.GetValues(typeof(EnumCategory)).Cast<EnumCategory>())
            {
                for (int i = 1; i < 6; i++)
                {
                    Grade grade = new Grade()
                    {
                        Category = dicoGrade[item].ToString(),
                        Quantity = i,
                        Ressource = dicoResource[item] + (i / 2),
                        Salary = dicoSalary[item]+(i*(int)item*1000)
                    };
                    IQueryable<Grade> query = context.Grades.Where(f => f.Category == grade.Category);
                    if (query.Count() == 0)
                    {
                        context.Grades.AddOrUpdate(grade);
                    }
                }
            }

        }
    }
}
