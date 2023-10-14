using CPF.ProductCatalog.Models;
using Microsoft.EntityFrameworkCore;

namespace CPF.ProductCatalog.Services.Data
{
    public class AppDb : DbContext
    {
        public DbSet<Product> Products { get; set; }


        public AppDb(DbContextOptions<AppDb> options) : base(options)
        {
            //
        } 
    }
}
