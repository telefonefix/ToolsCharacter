using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities.Characterize
{
    public interface IPatents
    {
        int Id { get; }

        string Name { get; set; }

        int Price { get; set; }

        int Empathy { get; set; }

        string Description { get; set; }

        Dictionary<Features, int> Features { get; set; }

        Dictionary<Skills, int> Skills { get; set; }
    }
}
