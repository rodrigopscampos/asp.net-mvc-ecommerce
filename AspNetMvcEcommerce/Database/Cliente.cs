using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AspNetMvcEcommerce
{
    public class Cliente
    {
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}