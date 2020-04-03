using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities.Characterize
{
    public class Protection : ICharacteristic<Protection>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
    }
}
