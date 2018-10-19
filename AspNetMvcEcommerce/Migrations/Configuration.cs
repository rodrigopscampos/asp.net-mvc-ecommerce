namespace AspNetMvcEcommerce.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AspNetMvcEcommerceContext>
    {
        static Random _random = new Random();

        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(AspNetMvcEcommerceContext context)
        {
            context.Categorias.AddOrUpdate(
                key => key.Descricao,

                GerarCategoria("Smartphones", 5, 200, 5000),
                GerarCategoria("Notebooks", 10, 800, 10000),
                GerarCategoria("TVs", 10, 400, 1000),
                GerarCategoria("Video Games", 3, 500, 2000)
                );

            var passwordHasher = new PasswordHasher();

            var admin = new Cliente
            {
                UserName = "admin@meu-ecommerce.com.br",
                Email = "admin@meu-ecommerce.com.br",
                SecurityStamp = Guid.NewGuid().ToString(),
                PasswordHash = passwordHasher.HashPassword("admin")
            };

            if (!context.Roles.Any(r => r.Name == "admin"))
            {
                var adminRole = new IdentityRole { Name = "admin" };
                context.Roles.Add(adminRole);
            }

            if (!context.Users.Any(u => u.UserName == "admin"))
            {
                context.Users.Add(admin);
                context.SaveChanges();

                var adminRole = context.Roles.FirstOrDefault(r => r.Name == "admin");

                admin.Roles.Add(new IdentityUserRole { RoleId = adminRole.Id, UserId = admin.Id });
                context.SaveChanges();
            }

            /*
                var manager = new ApplicationUserManager(new UserStore<Cliente>(context));
                manager.Create(admin, "admin");
                manager.AddToRole(admin.Id, "admin");
            */
        }

        private Categoria GerarCategoria(string descricao, int qtdadeProdutos, int precoMinimo, int precoMaximo)
        {
            var produtos = Enumerable.Range(0, qtdadeProdutos)
                .Select(i => new Produto
                {
                    Nome = $"{descricao} - Produto {i}",
                    Descricao = $"Produto {descricao} - Produto {i} ...",
                    Preco = _random.Next(precoMinimo * 100, precoMaximo * 100) / 100
                })
                .ToArray();

            return new Categoria
            {
                Descricao = descricao,
                Produtos = produtos
            };
        }
    }
}
