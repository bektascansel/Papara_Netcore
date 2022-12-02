using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using WebApi_Dapper.Data.Abstracts;
using WebApi_Dapper.Domain;
using WebApi_Dapper.Domain.Entities;

namespace WebApi_Dapper.Data.Concretes
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly string _connectionString = "Server=DESKTOP-LNGHJTG\\SQLEXPRESS;Database=Book;Trusted_Connection=true";
        public async Task DeleteAsync(Guid id)
        {
            await using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync($"DELETE FROM dbo.Book WHERE Id = '{id}'");
        }

        public async Task<Book> GetAsync(Guid id)
        {
            await using var connection = new SqlConnection(_connectionString);
            return await connection.QueryFirstAsync<Book>($"SELECT * FROM dbo.Book WHERE = '{id}'");

        }

        public async Task<List<Book>> GetListAsync()
        {
            await using var connection = new SqlConnection(_connectionString);

            return (await connection.QueryAsync<Book>("SELECT * FROM dbo.Book"))
                .AsList();
        }

        public async Task<Book> InsertAsync(Book book)
        {
            await using var connection = new SqlConnection(_connectionString);
            var query = $"INSERT INTO dbo.Book VALUES ('{book.Name}', '{book.WriterName}', '{(int)book.PageNumber})";
            await connection.ExecuteAsync(query);
            return book;
        }

        public async Task<Book> UpdateAsync(Guid id, Book book)
        {
            await using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync($"UPDATE dbo.Book SET {nameof(Book.Name)} = '{book.Name}', {nameof(Book.WriterName)} = '{book.WriterName}', {nameof(Book.PageNumber)} = {(int)book.PageNumber} WHERE Id = '{id}'");
            return book;
        }
    }
}
