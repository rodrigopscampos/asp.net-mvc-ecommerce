using System.Linq;

namespace AspNetMvcEcommerce.Models
{
    public class OrderModel : AspNetMvcEcommerce.Order
    {

        public decimal TotalPayment
        {
            get
            {
                return this.Order_Products.Sum(p => p.TotalSale);
            }
        }
    }
}