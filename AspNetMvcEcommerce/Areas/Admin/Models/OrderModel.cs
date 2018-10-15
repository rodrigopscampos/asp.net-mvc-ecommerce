using System.Linq;

namespace AspNetMvcEcommerce.Models
{
    public class OrderModel : AspNetMvcEcommerce.Ordem
    {

        public decimal TotalPayment
        {
            get
            {
                return this.Itens.Sum(p => p.TotalSale);
            }
        }
    }
}