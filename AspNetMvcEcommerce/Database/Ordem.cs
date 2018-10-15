using System;
using System.Collections.Generic;

namespace AspNetMvcEcommerce
{
    public partial class Ordem
    {
        public int Id { get; set; }

        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }

        public int CustumerId { get; set; }
        public virtual Cliente Cliente { get; set; }

        public int Order_ProductsId { get; set; }
        public virtual ICollection<OrdemItem> Order_Products { get; set; }
    }
}