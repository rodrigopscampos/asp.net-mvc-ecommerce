namespace AspNetMvcEcommerce
{
    public partial class Order_Products
    {
        public int Id { get; set; }

        public int OrderID { get; set; }
        public int Qty { get; set; }
        public decimal TotalSale { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}