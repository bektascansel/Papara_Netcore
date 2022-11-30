using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Data.Abstracts;
using RepositoryPattern.Data.Context;
using RepositoryPattern.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Data.Concretes
{
    public class Repository<T> : IRepository<T> where T : BaseEntitiy
    {
        AppDBContext _context;
        public Repository(AppDBContext context)
        {
            _context = context;
        }
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            T existData = _context.Set<T>().Find(entity.Id);
            if (existData != null)
            {
                existData.IsDeleted = true;
                _context.Entry(existData).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }

        public IQueryable<T> Get()
        {
            return _context.Set<T>().Where(x => !x.IsDeleted).AsQueryable();
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression).AsQueryable();
        }

        public void GetById(int id)
        {
            _context.Set<T>().Find(id);
            _context.SaveChanges();
        }

        public void HardDelete(T entity)
        {
            T existData = _context.Set<T>().Find(entity.Id);
            if (existData != null)
                _context.Set<T>().Remove(existData);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
