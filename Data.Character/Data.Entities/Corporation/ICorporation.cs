using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities.Corporation
{

    public interface ICorporation
    {
        string Name { get; set; }

        IGrade Grade { get; set; }

        void CreateCorporation(string name,IGrade grade);
        void CreateCorporation(string name,Category category,int qty);
    }
}
