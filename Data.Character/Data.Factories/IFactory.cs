using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Factories
{
    public interface IFactory
    {
        bool Success { get; set; }
        string Name { get; set; }
        string FirstName { get; set; }
        
        void CreateCharacter(List<string> characterize, string gender);
        List<string> GetEnumList<T>(T t);
    }
}
