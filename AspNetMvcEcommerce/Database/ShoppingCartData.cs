namespace AspNetMvcEcommerce
{
    public class ShoppingCartData
    {
        public int Id { get; set; }

        public int TempOrderID { get; set; }
        public string PName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}