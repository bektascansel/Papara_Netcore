using RepositoryPattern.Domain.Entities;
using System;
using System.Collections.Generic;


namespace RepositoryPattern.Services.Abstarccts
{
    public interface IBookService
    {
        public IEnumerable<Book> GetAll();

        public void Add(Book book);
        public void Update(Book book);
        public void Delete(Book book);
        public void HardDelete(Book book);
        public void GetById(int Id);

    }
}
