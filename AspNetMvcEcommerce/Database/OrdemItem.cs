namespace AspNetMvcEcommerce
{
    public partial class OrdemItem
    {
        public int Id { get; set; }

        public int OrderID { get; set; }
        public int Qty { get; set; }
        public decimal TotalSale { get; set; }
    }
}