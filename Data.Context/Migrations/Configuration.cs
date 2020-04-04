namespace Data.Context.Migrations
{
    using Data.Entities.Characterize;
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

            SetFeature(context);
            SetEthnic(context);
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
    }
}
