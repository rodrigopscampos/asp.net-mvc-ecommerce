using System;
using System.Collections.Generic;

namespace AspNetMvcEcommerce
{
    public partial class Order
    {
        public int Id { get; set; }

        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }

        public int CustumerId { get; set; }
        public virtual Customer Customer { get; set; }

        public int Order_ProductsId { get; set; }
        public virtual ICollection<Order_Products> Order_Products { get; set; }
    }
}