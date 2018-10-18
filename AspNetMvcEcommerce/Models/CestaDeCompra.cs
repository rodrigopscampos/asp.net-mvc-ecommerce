﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace AspNetMvcEcommerce.Models
{
    public class CestaDeCompra
    {
        public Dictionary<int, CestaDeCompraItem> Itens { get; set; }
            = new Dictionary<int, CestaDeCompraItem>();

        public decimal PrecoTotal
            => Itens.Sum(i => i.Value.PrecoTotal);

        public int QuantidadeDeProdutos => Itens.Count;

        public void Limpar()
        {
            Itens.Clear();
        }

        public void AdicionaProduto(Produto produto)
        {
            if (Itens.ContainsKey(produto.Id))
            {
                Itens[produto.Id].Quantidade++;
            }
            else
            {
                Itens.Add(produto.Id, new CestaDeCompraItem
                {
                    ProdutoId = produto.Id,
                    PrecoUnitario = produto.Preco,
                    NomeDoProduto = produto.Nome,
                    Quantidade = 1
                });
            }
        }

        public CestaDeCompraItem GetItem(int id)
        {
            return Itens[id];
        }

        public void SetItem(CestaDeCompraItem produto)
        {
            Itens[produto.ProdutoId] = produto;
        }

        public void Remove(int id)
        {
            Itens.Remove(id);
        }
    }

    public class CestaDeCompraItem
    {
        public int ProdutoId { get; set; }
        public string NomeDoProduto { get; set; }
        public decimal PrecoUnitario { get; set; }
        public int Quantidade { get; set; }

        public decimal PrecoTotal => PrecoUnitario * Quantidade;
    }
}