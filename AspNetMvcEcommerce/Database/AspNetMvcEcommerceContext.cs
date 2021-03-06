﻿using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace AspNetMvcEcommerce
{
    public class AspNetMvcEcommerceContext : IdentityDbContext<Cliente>
    {
        public AspNetMvcEcommerceContext()
            :base("AspNetMvcEcommerce")
        {
        }

        public static AspNetMvcEcommerceContext Create()
        {
            return new AspNetMvcEcommerceContext();
        }

        public virtual DbSet<Ordem> Ordens { get; set; }
        public virtual DbSet<Produto> Produtos { get; set; }
        public virtual DbSet<Categoria> Categorias { get; set; }
    }
}