using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities.Corporation
{
    public enum Category
    {
        Circle,
        Triangle,
        Star
    }

    public interface IGrade
    {
        Category Category { get; set; }

        int Qty { get; set; }
        string Rank { get; set; }

    }
}
