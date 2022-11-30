using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Data.Abstracts
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll(Expression<Func<T,bool>>expression);
        IQueryable<T> Get();
        public void Add(T entity);
        public void Update(T entity);
        //veri tabanından gizler 
        void Delete(T entity);


        void GetById(int id);


        //veritabanından komple siler 
        void HardDelete(T entity);






    }
}
