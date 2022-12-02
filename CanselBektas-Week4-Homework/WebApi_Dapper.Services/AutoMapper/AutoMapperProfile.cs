using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi_Dapper.Data.DTO;
using WebApi_Dapper.Domain.Entities;

namespace WebApi_Dapper.Services.AutoMapper
{
    public class AutoMapperProfile: Profile
    {
        
        public AutoMapperProfile()
        {
            CreateMap<Book, BookDto>();

            CreateMap<CreateUpdateBookDto, Book>();
        }
    }
}
