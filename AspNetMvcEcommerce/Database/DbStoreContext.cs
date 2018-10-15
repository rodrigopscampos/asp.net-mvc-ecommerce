using System.Data.Entity;

namespace AspNetMvcEcommerce
{
    public class DbStoreContext : DbContext
    {
        public DbStoreContext()
        {

        }

        public virtual DbSet<Cliente> Customers { get; set; }
        public virtual DbSet<OrdemItem> Order_Products { get; set; }
        public virtual DbSet<Ordem> Orders { get; set; }
        public virtual DbSet<Produto> Products { get; set; }
        public virtual DbSet<ShoppingCartData> ShoppingCartDatas { get; set; }
    }
}