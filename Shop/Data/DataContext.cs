using Microsoft.EntityFrameworkCore;
using Shop.Models;

namespace Shop.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        // DbSet = representação das tabelas. Então se eu tenho um DbSet<Product>,
        // uma tabela chamada Product vai ser buscada no banco e o mapeamento com
        // o modelo Product vai ser feito.
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
