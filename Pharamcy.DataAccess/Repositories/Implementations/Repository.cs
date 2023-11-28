using Microsoft.EntityFrameworkCore;
using Pharamcy.Core.Models;
using Pharamcy.DataAccess.DbContext;
using Pharamcy.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pharamcy.DataAccess.Repositories.Implementations
{
    public class Repository<T> : IRepository<T> where T : BaseModel
    {
        PharamcyDbContext _pharamcyDbContext = new PharamcyDbContext();
        

        private readonly DbSet<T> _dbset;
        public Repository()
        {
            _dbset = _pharamcyDbContext.Set<T>();
        }
        public List<T> GetAll()
        {
            return _dbset.ToList();
        }

        public T GetbyId(int id)
        {
            return _dbset.Find(id);
        }
        public void Create(T entity)
        {
            _dbset.Add(entity);
            _pharamcyDbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            _dbset.Update(entity);
            _pharamcyDbContext.SaveChanges();
        }
        public void Delete(T entity)
        {
            _dbset.Remove(entity);
            _pharamcyDbContext.SaveChanges();
        }

        public bool Any(Expression<Func<T, bool>> predicate)
        {
            return _dbset.Any(predicate);
        }

        public void SaveChanges()
        {
            _pharamcyDbContext.SaveChangesAsync();
        }

        public T FirstorDefault()
        {
            return _dbset.FirstOrDefault();
        }
    }
}
