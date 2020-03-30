using Data.Entities.Characterize;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities.Patent
{
    public interface IPatent
    {
        int Id { get; }

        string Name { get; set; }

        int Price { get; set; }

        int Empathy { get; set; }

        string Description { get; set; }

        Dictionary<Feature, int> Features { get; set; }

        Dictionary<Skill, int> Skills { get; set; }
    }
}
