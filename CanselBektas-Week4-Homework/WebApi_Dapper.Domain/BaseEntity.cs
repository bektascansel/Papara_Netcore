using System;

namespace WebApi_Dapper.Domain
{
    public abstract class BaseEntity
    {

        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }

        //null olarak geçilebilir
        public DateTime? LastUpdateDate { get; set; }
        public string LastUpdatedBy { get; set; }



    }
}
