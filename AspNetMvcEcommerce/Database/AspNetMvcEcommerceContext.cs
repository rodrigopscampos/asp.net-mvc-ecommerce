using System.Data.Entity;

namespace AspNetMvcEcommerce
{
    public class AspNetMvcEcommerceContext : DbContext
    {
        public AspNetMvcEcommerceContext()
            :base("AspNetMvcEcommerce")
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<OrdemItem> IrdemItens { get; set; }
        public virtual DbSet<Ordem> Ordens { get; set; }
        public virtual DbSet<Produto> Produtos { get; set; }
        public virtual DbSet<Categoria> Categorias { get; set; }
    }
}