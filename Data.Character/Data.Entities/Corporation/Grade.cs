using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities.Corporation
{
    


    public class Grade : IGrade
    {
        public Category Category { get; set; }

        public int Qty { get; set; }

        public string Rank { get; set; }

    }
}
