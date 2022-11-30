using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Domain.Entities
{
    public class Book : BaseEntitiy
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string WriterName { get; set; }
        public int PageNumber { get; set; }


    }
}
