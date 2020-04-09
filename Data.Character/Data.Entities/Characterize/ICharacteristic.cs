using Data.Entities.Person;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities.Characterize
{
    public interface ICharacteristic<TEntity> where TEntity : class
    {
        int Id { get; set; }
        string Name { get; set; }

    }
}
