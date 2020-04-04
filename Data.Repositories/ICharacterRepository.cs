﻿using Data.Entities.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public interface ICharacterRepository
    {
        void Create(string firstName, string lastName, string pseudo, EnumGender gender);
        void Update();
    }
}
