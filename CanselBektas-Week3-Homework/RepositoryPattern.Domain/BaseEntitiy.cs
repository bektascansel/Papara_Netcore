﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Domain
{
    public abstract class BaseEntitiy
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }

        //null olarak geçilebilir
        public DateTime? LastUpdateDate { get; set; }
        public string LastUpdatedBy { get; set; }

    }
}
