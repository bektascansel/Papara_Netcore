using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi_Dapper.Data.DTO
{
    public class BookDto
    {
        public Guid Id { get; set; }

        [Required]
        [NotNull]
        public bool IsDeleted { get; set; }

        [Required]
        [NotNull]
        public DateTime CreatedDate { get; set; }


        [Required]
        [NotNull]
        public string CreatedBy { get; set; }

        public DateTime LastUpdateDate { get; set; }

        [Required]
        [NotNull]
        public string LastUpdateBy { get; set; }

        [Required]
        [NotNull]
        public string Name { get; set; }

        [Required]
        [NotNull]
        public string WriteName { get; set; }

        [Required]
        [NotNull]
        public int PageNumber { get; set; }
        

    }
}
