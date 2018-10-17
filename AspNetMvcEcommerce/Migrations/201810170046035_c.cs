namespace AspNetMvcEcommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class c : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ShoppingCartDatas", newName: "CarrinhoDeComprasItems");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.CarrinhoDeComprasItems", newName: "ShoppingCartDatas");
        }
    }
}
