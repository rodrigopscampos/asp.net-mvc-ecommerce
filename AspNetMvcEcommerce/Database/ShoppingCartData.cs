namespace AspNetMvcEcommerce
{
    public class ShoppingCartData
    {
        public int Id { get; set; }
        
        public string NomeDoProduto { get; set; }
        public decimal PrecoUnitario { get; set; }
        public int Quantidade { get; set; }
    }
}