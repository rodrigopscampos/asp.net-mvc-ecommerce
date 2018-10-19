namespace AspNetMvcEcommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AspNetMvcEcommerce.AspNetMvcEcommerceContext>
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

            context.SaveChanges();
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
