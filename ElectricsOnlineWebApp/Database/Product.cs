﻿using System.Collections.Generic;

namespace ElectricsOnlineWebApp
{

    public partial class Product
    {
        public int Id { get; set; }

        public string PName { get; set; }
        public string Brand { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public int SID { get; set; }
        public int ROL { get; set; }

        public virtual ICollection<Order_Products> Order_Products { get; set; }
    }
}