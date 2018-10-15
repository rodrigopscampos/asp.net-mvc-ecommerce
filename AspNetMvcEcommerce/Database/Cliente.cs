using System;

namespace AspNetMvcEcommerce
{
    public class Cliente
    {
        public int Id { get; set; }

        public string Nome { get; set; }
        public string Phone { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string CEP { get; set; }
        public string Estado { get; set; }
        public string CcNumero { get; set; }
        public DateTime CcValidade { get; set; }
        public string Email { get; set; }
    }
}