using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi_Dapper.Domain;

namespace WebApi_Dapper.Domain.Entities
{
    public  class Book : BaseEntity
    {
      

        [Required]
            public string Name { get; set; }

            [Required]
            public string WriterName { get; set; }
            public int PageNumber { get; set; }



        }
    }

