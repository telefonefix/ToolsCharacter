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
        public string Name { get; set; }
        public int Value { get; set; }
        public int Id { get; set; }       
        public int IdFeatures { get; set; }
        public int AcquiredPoint { get; set; }

    }
}
