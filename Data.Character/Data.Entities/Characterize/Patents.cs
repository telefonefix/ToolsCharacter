using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities.Characterize
{
    public class Patents : IPatents
    {        
        public string Name { get; set; }

        public int Price { get; set; }
        
        public int Empathy { get; set; }

        public string Description { get; set; }

        public Dictionary<Features,int> Features { get; set; }

        public Dictionary<Skills, int> Skills { get; set; }

        public int Id { get; }
    }
}
