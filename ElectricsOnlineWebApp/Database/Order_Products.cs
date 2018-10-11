namespace ElectricsOnlineWebApp
{
    public partial class Order_Products
    {
        public int OrderID { get; set; }
        public int PID { get; set; }
        public int Qty { get; set; }
        public decimal TotalSale { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}