using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities.Characterize
{
    public class Features : IRepository<Features>
    {
        //private FeatureList _featureName;


        public string Name { get; set; }
        public int Value { get; set; }

        public bool checkName(string name)
        {
            // TODO : Faire le check si un nouveau nom est entrée
            try
            {
                //_featureName.CompareTo(name);
            }
            catch (Exception e)
            {

                throw e;
            }

            return false;
        }
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
