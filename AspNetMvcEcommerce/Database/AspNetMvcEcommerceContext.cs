using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AspNetMvcEcommerce
{
    public class AspNetMvcEcommerceContext
    {
        private static List<Ordem> _ordens = new List<Ordem>();
        private static List<Produto> _produtos = new List<Produto>();
        private static List<Categoria> _categorias = new List<Categoria>();

        public List<Ordem> Ordens => _ordens;
        public List<Produto> Produtos => _produtos;
        public List<Categoria> Categorias => _categorias;

        static AspNetMvcEcommerceContext()
        {
            var smartphones = GerarProdutos(5, "Smartphones", 200);
            var notebooks = GerarProdutos(10, "Notebooks", 400);
            var tvs = GerarProdutos(4, "TVs", 400);
            var videoGames = GerarProdutos(3, "Video Games", 500);

            _produtos.AddRange(smartphones);
            _categorias.Add(GerarCategoria("Smartphones", smartphones));

            _produtos.AddRange(notebooks);
            _categorias.Add(GerarCategoria("Notebooks", notebooks));

            _produtos.AddRange(tvs);
            _categorias.Add(GerarCategoria("TVs", tvs));

            _produtos.AddRange(tvs);
            _categorias.Add(GerarCategoria("Video Games", videoGames));
        }

        public void SaveChanges() { }


        public static IEnumerable<Produto> GerarProdutos(int qtdadeProdutos, string descricao, decimal precoMinimo)
        {
            return Enumerable.Range(0, qtdadeProdutos)
              .Select(i => new Produto
              {
                  Nome = $"{descricao} - Produto {i}",
                  Descricao = $"Produto {descricao} - Produto {i} ...",
                  Preco = (precoMinimo += precoMinimo / 2)
              })
              .ToArray();
        }

        public static Categoria GerarCategoria(string descricao, IEnumerable<Produto> produtos)
        {
            var categoria = new Categoria
            {
                Descricao = descricao,
                Produtos = produtos.ToArray()
            };

            foreach (var p in produtos)
                p.Categoria = categoria;

            return categoria;
        }
    }
}