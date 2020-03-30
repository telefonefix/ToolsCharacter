using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public interface ICorporationRepository
    {
        void Create(string name, string grade);

        void Upgrade(string name, string grade);

    }
}
