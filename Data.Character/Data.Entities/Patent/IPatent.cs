using Data.Entities.Characterize;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities.Patent
{
    public interface IPatent
    {
        int Id { get; set; }
        string Name { get; set; }
        int Price { get; set; }
        string Description { get; set; }        
        string SecondEffect { get; set; }
        decimal ChanceToDie { get; set; }
        decimal ChanceToBeMad { get; set; }

        Dictionary<Feature, int> Features { get; set; }

        Dictionary<Skill, int> Skills { get; set; }
    }
}
