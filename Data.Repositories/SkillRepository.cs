using Data.Entities.Characterize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class SkillRepository : ICharacteristic<Skill>
    {
        public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Value { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Create()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
