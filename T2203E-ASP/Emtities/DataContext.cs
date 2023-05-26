using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
namespace T2203E_ASP.Emtities
{
    public class DataContext : DbContext// kế thừa DbContext có sẵn
    {
        public DataContext(DbContextOptions<DataContext> options)
           : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }


    }
}
