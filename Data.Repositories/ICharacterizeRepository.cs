using Data.Entities.Characterize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public interface ICharacterizeRepository<T> where T : class, ICharacteristic<T>
    {   
        void Create<ICharacteristic>(T t, ICharacteristic<T> charac, string name);
        void Update();
    }
}
