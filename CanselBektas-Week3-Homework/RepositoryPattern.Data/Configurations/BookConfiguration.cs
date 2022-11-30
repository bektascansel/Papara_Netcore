using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepositoryPattern.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Data.Configurations
{

    /// <summary>
    /// İlgili Db set burada şekillendirilir.IEntityTypeConfiguration interface'i Book tablo yapacak yapıdır.
    /// </summary>
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            //zorunlu olan alanları belirtir.IsRequired kısmı
            builder.Property(x => x.WriterName).IsRequired();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Id).UseIdentityColumn();
            //Tablo oluşturdu
            builder.ToTable("Books");
        }
    }
}
