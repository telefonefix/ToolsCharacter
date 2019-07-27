using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities.Characterize
{
    public enum SkillsList
    {
        Perc_Humaine,
        Survie_Milieu_Hostile,
        Se_Cacher,
        Conn_Systeme,
        Conn_des_Systemes
    }

    public class Skills : IRepository<Skills>
    {
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Value { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
