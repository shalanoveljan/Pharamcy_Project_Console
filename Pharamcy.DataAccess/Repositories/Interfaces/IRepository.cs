using Pharamcy.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pharamcy.DataAccess.Repositories.Interfaces
{
    public interface IRepository<T> where T : BaseModel
    {
        List<T> GetAll();
        T GetbyId(int id);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        bool Any(Expression<Func<T, bool>> predicate);
        void SaveChanges();
        T FirstorDefault();
    }
}
