namespace AspNetMvcEcommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class session : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.CarrinhoDeComprasItems");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CarrinhoDeComprasItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomeDoProduto = c.String(),
                        PrecoUnitario = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantidade = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
