﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities.Characterize
{
    public class Resources : IRepository<Resources>
    {
        public string Name { get; set; }
        public int Value { get; set; }
    }
}
