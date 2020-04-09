using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities.Attribute
{
    public interface IAttribute<TEntity> where TEntity : class
    {
        int IdCharactere { get; set; }

        int Id { get; set; }

        int Value { get; set; }

        int Multiplier { get; set; }

        int Acquired { get; set; }

    }
}
