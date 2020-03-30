using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities.Characterize
{
    public interface ICharacteristic<T>
    {
        int Id { get; set; }

        string Name { get; set; }

        int Value { get; set; }
    }
}
