namespace AspNetMvcEcommerce
{
    public class CarrinhoDeComprasItem
    {
        public int Id { get; set; }
        
        public string NomeDoProduto { get; set; }
        public decimal PrecoUnitario { get; set; }
        public int Quantidade { get; set; }
    }
}