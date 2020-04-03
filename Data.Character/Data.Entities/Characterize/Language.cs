using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities.Characterize
{
    public class Language : ICharacteristic<Language>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Value { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
