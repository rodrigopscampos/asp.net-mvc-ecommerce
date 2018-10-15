namespace AspNetMvcEcommerce
{
    public partial class OrdemItem
    {
        public int Id { get; set; }

        public int OrdemId { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorTotal { get; set; }
    }
}