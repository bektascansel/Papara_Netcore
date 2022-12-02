using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi_Dapper.Data.DTO;
using WebApi_Dapper.Domain.Entities;

namespace WebApi_Dapper.Services.Abstrcats
{
    public interface IBookService
    {
        Task<List<BookDto>> GetBooksAsync();

        Task<BookDto> GetAsync(Guid id);

        Task CreateAsync(CreateUpdateBookDto book);

        Task UpdateAsync(Guid id, CreateUpdateBookDto book);

        Task DeleteAsync(Guid id);
        Task GetAsync();
    }
}
