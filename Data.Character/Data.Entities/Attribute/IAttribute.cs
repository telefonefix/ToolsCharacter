using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities.Attribute
{
    public interface IAttribute<T>
    {
        int IdCharactere { get; set; }

        int Value { get; set; }

        int Multiplier { get; set; }

        int Acquired { get; set; }

    }
}
