﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Factories
{
    internal class CharacterException : Exception
    {
        public CharacterException() { }

        public CharacterException(string message) : base(message) { }

        public CharacterException(string message, Exception inner) : base(message,inner) { }

    }
}
