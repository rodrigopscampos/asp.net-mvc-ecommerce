using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AspNetMvcEcommerce.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome é requerido")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }
        
        [Display(Name = "Telefone")]
        [Required(ErrorMessage = "Telefone é requerido")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Telefone precisa ter entre 3 a 15 digitos")]
        public string Phone { get; set; }

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "Estado é requerido")]
        public string Estado { get; set; }

        [Display(Name = "Endereço")]
        [Required(ErrorMessage = "Endereço é requerido")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "CEP é requerido")]
        public string CEP { get; set; }

        [Required(ErrorMessage = "Número do Cartão de Crédito é requerido")]
        [Display(Name = "Número")]
        public string CcNumero { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "Validade do cartão é requerida")]
        [Display(Name = "Validade")]
        public DateTime CcValidade { get; set; } = DateTime.Today.AddYears(1);

        [Required(ErrorMessage = "Email é requerido")]
        [EmailAddress]
        public string Email { get; set; }
    }
}