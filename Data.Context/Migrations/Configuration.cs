namespace Data.Context.Migrations
{
    using Data.Entities.Characterize;
    using Data.Entities.Person;
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Data.Context.CharactereContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CharactereContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            SetFeature(context);
            SetEthnic(context);

        }

        private void SetFeature(CharactereContext context)
        {
            foreach (FeaturesList feature in Enum.GetValues(typeof(FeaturesList)).Cast<FeaturesList>())
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
            foreach (EthnicList ethnic in Enum.GetValues(typeof(EthnicList)).Cast<EthnicList>())
            {
                Ethnic eth = new Ethnic()
                {
                    Name = ethnic.ToString()
                };

                IQueryable<Ethnic> query = context.Ethnics.Where(e=> e.Name == eth.Name);
                if (query.Count() == 0)
                {
                    context.Ethnics.AddOrUpdate(eth);
                }
            }
        }
}
}
