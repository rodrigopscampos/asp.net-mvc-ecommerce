using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AspNetMvcEcommerce.Models
{
    public class Cliente
    {
        [Required(ErrorMessage = "Nome é requerido")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }
        
        [Display(Name = "Telefone")]
        [Required(ErrorMessage = "Telefone é requerido")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Telefone must be 10 digits")]
        public string Phone { get; set; }

        [Display(Name = "Endereço")]
        [Required(ErrorMessage = "Endereço é requerido")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "Bairro é requerido")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "CEP é requerido")]
        public string CEP { get; set; }

        [Required(ErrorMessage = "Estado é requerido")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "Número do Cartão de Crédito é requerido")]
        [Display(Name = "Número do Cartão de Crédito")]
        public string CcNumero { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "Validade do cartão é requerida")]
        [Display(Name = "Expiration")]
        public DateTime CcValidade { get; set; }

        [Required(ErrorMessage = "Email é requerido")]
        [EmailAddress]
        public string Email { get; set; }


        //todo
        [Display(Name = "State")]
        public IEnumerable<SelectListItem> States { get; set; }
    }
}