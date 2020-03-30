using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities.Characterize
{
    public class Feature : ICharacteristic<Feature>
    {
        public string Name { get; set; }
        public int Value { get; set; }
        public int Id { get; set; }
    }

    public enum FeaturesList
    {
        BT = 0,
        CON = 1,
        EMP = 2,
        MVT = 3,
        SF = 4,
        TECH = 5,
        INT = 6,
        REF = 7
    }   
}
