using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Data.Configurations;
using RepositoryPattern.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Data.Context
{
    public class AppDBContext:DbContext
    {

        public DbSet<Book> Books { get; set; } //Book classının tablo olacağı belirtildi.

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);  //yukarıda oluşturulan db setleri tablo yapacak olan kısım.
            modelBuilder.ApplyConfiguration(new BookConfiguration()); //configuration dosyalarını veri tabanına uygulayan metottur. 
        }

        /// <summary>
        /// istersek sql server baglantısını burada yaratabiliriz.
        /// </summary>
        /// <param name="optionsBuilder"></param>
        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-LNGHJTG\SQLEXPRESS; Databse=BookDb; Trusted_Connection=true");
        }
        */  





    }
}
