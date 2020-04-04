using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities.Corporation
{
    public enum EnumCategory
    {
        Circle,
        Triangle,
        Star
    }

    public interface IGrade
    {
        int Id { get; set; }
        EnumCategory Category { get; set; }

        int Qty { get; set; }
        string Rank { get; set; }

    }
}
