using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities.Characterize
{
    public interface IRepository<T>
    {
        string Name { get; set; }

        int Value { get; set; }
    }
}
