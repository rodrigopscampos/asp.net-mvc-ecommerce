using System.Data.Entity;

namespace AspNetMvcEcommerce
{
    public class DbStoreContext : DbContext
    {
        public DbStoreContext()
        {

        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order_Products> Order_Products { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ShoppingCartData> ShoppingCartDatas { get; set; }
    }
}