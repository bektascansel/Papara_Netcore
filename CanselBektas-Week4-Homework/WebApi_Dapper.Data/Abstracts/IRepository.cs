using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebApi_Dapper.Domain.Entities;

namespace WebApi_Dapper.Data.Abstracts
{
    public interface IRepository<T> where T : class
    {
        /*
        IQueryable<T> GetAll(Expression<Func<T, bool>> expression);

        //expression ile sorgulama yapılacak 
        IQueryable<T> Get();

        void Add(T entity);


        void Update(T entity);

        //veri tabanından gizler 
        void Delete(T entity);


        void GetById(int id);


        //veritabanından komple siler 
        void HardDelete(T entity);
        */
        Task<List<Book>> GetListAsync();

        Task<Book> GetAsync(Guid id);

        Task<Book> InsertAsync(Book book);

        Task<Book> UpdateAsync(Guid id, Book book);

        Task DeleteAsync(Guid id);

    }
}
