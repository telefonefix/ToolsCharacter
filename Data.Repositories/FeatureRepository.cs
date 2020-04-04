using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities.Characterize;

namespace Data.Repositories
{
    public class FeatureRepository : ICharacterizeRepository<Feature>
    {
        private DbCharacterizeRepository<Feature> _dbRepository;
       
        public FeatureRepository(DbCharacterizeRepository<Feature> dbRepository)
        {
            _dbRepository = dbRepository;

        }

        public void Create<ICharacteristic>(Feature feature,ICharacteristic<Feature> charac, string name)
        {   
            using (_dbRepository.Context)
            {
                IEnumerable<Feature> query = _dbRepository.Context.Features.Where(f => f.Name == name);

                if (query.Count() == 0)
                {
                    feature.Name = name;
                    _dbRepository.Add<Feature>(feature);
                }
                //_dbRepository.Context.SaveChanges();

            }
            //if (id == 0)
            //{
            //    //_dbRepository.Add<Feature>()
            //    _dbRepository.Add<Feature>(feature);
            //}



        }

        private int GetId(Feature feature,string name)
        {
            using (_dbRepository.Context)
            {
                IEnumerable<Feature> query = _dbRepository.Context.Features.Where(f => f.Name == name);

                if (query.Count() == 0) return 0;

                return _dbRepository.Context.Features.FirstOrDefault(f => f.Name == name).Id;
            }
            
        }

        

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
