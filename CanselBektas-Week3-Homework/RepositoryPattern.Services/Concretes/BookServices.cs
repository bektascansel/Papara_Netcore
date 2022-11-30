using RepositoryPattern.Data.Abstracts;
using RepositoryPattern.Domain.Entities;
using RepositoryPattern.Services.Abstarccts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Services.Concretes
{
    public class BookServices: IBookService
    {
        private readonly IRepository<Book> bookRepository;

        public BookServices(IRepository<Book> _bookRepository)
        {
            bookRepository = _bookRepository;

        }
        public void Add(Book book)
        {
            bookRepository.Add(book);
        }

        public void Delete(Book book)
        {
            bookRepository.Delete(book);
        }

        public IEnumerable<Book> GetAll()
        {
            return bookRepository.Get().ToList();
        }

        public void GetById(int Id)
        {
            bookRepository.GetById(Id);
        }

        public void HardDelete(Book book)
        {
            bookRepository.HardDelete(book);
        }

        public void Update(Book book)
        {
            bookRepository.Update(book);
        }

        
        }
    }
