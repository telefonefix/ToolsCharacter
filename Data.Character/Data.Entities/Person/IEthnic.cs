using System.Collections.Generic;

namespace Data.Entities.Person
{
    public interface IEthnic
    {
        int IdEthnic { get; set; }

        string Name { get; set; }


        ICollection<Character> Characters { get; set; }
    }
}
