using System.Data.Entity;

namespace ElectricsOnlineWebApp
{
    public class ElectricsOnlineEntities : DbContext
    {
        public ElectricsOnlineEntities()
        {

        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order_Products> Order_Products { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ShoppingCartData> ShoppingCartDatas { get; set; }
    }
}