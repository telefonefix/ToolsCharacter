using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities.Places
{
    public interface IPlace
    {
        int Id {get; set;}

        string Name { get; set; }
    }
}
