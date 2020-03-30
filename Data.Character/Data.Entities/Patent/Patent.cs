using System;
using System.Collections.Generic;
using System.Text;
using Data.Entities.Characterize;

namespace Data.Entities.Patent
{
    public class Patent : IPatent
    {        
        public string Name { get; set; }

        public int Price { get; set; }
        
        public int Empathy { get; set; }

        public string Description { get; set; }

        public Dictionary<Feature,int> Features { get; set; }

        public Dictionary<Skill, int> Skills { get; set; }

        public int Id { get; }
      
    }
}
