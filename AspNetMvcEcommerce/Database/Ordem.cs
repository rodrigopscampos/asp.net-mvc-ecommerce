using System;
using System.Collections.Generic;

namespace AspNetMvcEcommerce
{
    public partial class Ordem
    {
        public int Id { get; set; }

        public DateTime DataDeCriacao { get; set; }
        public DateTime DataDeEntrega { get; set; }

        public string ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }

        public int ItensId { get; set; }
        public virtual ICollection<OrdemItem> Itens { get; set; }

        public string Endereco { get; set; }
        public string CEP { get; set; }
        public string CcNumero { get; set; }
        public DateTime? CcValidade { get; set; }
    }
}