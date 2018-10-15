using System.Collections.Generic;

namespace AspNetMvcEcommerce
{

    public partial class Produto
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
    }
}