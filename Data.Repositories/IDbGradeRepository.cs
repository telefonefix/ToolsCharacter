using Data.Entities.Enterprise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public interface IDbGradeRepository : IDisposable
    {
        IQueryable<Grade> GetAll(bool noTracking = true);

        int GetId(string category,int quantity);

        int Id { get; set; }
    }
}
