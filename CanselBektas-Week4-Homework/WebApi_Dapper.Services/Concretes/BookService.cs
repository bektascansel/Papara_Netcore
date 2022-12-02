using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi_Dapper.Data.Abstracts;
using WebApi_Dapper.Data.DTO;
using WebApi_Dapper.Domain.Entities;
using WebApi_Dapper.Services.Abstrcats;
using WebApi_Dapper.Services.Concretes;

namespace WebApi_Dapper.Services.Concretes
{
    public class BookService : IBookService
    {
        private readonly IRepository<Book> bookRepository;
        private readonly IMapper _mapper;

        public BookService(IRepository<Book> _bookRepository, IMapper mapper)
        {
            bookRepository = _bookRepository;
            _mapper = mapper;

        }
        public async Task CreateAsync(CreateUpdateBookDto book)
        {
            var _book = new Book
            {   
                Name = book.Name,
                WriterName=book.WriteName,
                PageNumber=book.PageNumber,
            };

            await bookRepository.InsertAsync(_book);
        }

        public async Task DeleteAsync(Guid id)
        {
            await bookRepository.DeleteAsync(id);
        }

        public async Task<BookDto> GetAsync(Guid id)
        {
            var book = await bookRepository.GetAsync(id);

            return _mapper.Map<Book, BookDto>(book);
        }

        public async Task<List<BookDto>> GetBooksAsync()
        {
            var book = await bookRepository.GetListAsync();

            return _mapper.Map<List<Book>, List<BookDto>>(book);
        }

        public async Task UpdateAsync(Guid id, CreateUpdateBookDto book)
        {
            var _book = new Book
            {
                Name = book.Name,
                WriterName = book.WriteName,
                PageNumber = book.PageNumber,
            };

            await bookRepository.UpdateAsync(id, _book);
        }

        Task IBookService.GetAsync()
        {
            throw new NotImplementedException();
        }
    }
}
