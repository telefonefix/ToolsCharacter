using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities.Corporation
{
    public class Corporation : ICorporation
    {
        #region Attributs
        private IGrade _grade;
        

        public IGrade Grade {
            get
            {
                return _grade;
            }
            set
            {
                _grade = value;
            }
        }
        #endregion Attributs

        #region Properties
        public string Name { get; set; }

        public Corporation(IGrade grade)
        {
            _grade = grade;
            //SetGrade(grade);
        }
        #endregion Properties

        // TODO : A voir s'il faut supprimer
        private void SetGrade(Grade grade)
        {
            Grade = new Grade()
            {
                Category = grade.Category,
                Qty = grade.Qty
            };
        }

        public void CreateCorporation(string name,IGrade grade)
        {
            Name = name;
            _grade = grade;            
        }

        // Category (Circle, Triangle, Star)
        public void CreateCorporation(string name, Category category, int qty)
        {
            Name = name;
            _grade.Category = category;
            _grade.Qty = qty;
            _grade.Rank = SetRank(category, qty);
        }

        private string SetRank(Category category,int qty)
        {
            char r;
            char[] rk = { (char)9, (char)31, '*' };
            switch (category)
            {
                case Category.Circle:
                    r = rk[0];
                    break;
                case Category.Triangle:
                    r = rk[1];
                    break;
                case Category.Star:
                    r = rk[2];
                    break;
                default:
                    r = rk[0];
                    break;
            }

            return new string(r, qty);
        }
    }
}
