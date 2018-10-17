namespace AspNetMvcEcommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrdemItems", "Ordem_Id", "dbo.Ordems");
            DropIndex("dbo.OrdemItems", new[] { "Ordem_Id" });
            RenameColumn(table: "dbo.OrdemItems", name: "Ordem_Id", newName: "OrdemId");
            AddColumn("dbo.OrdemItems", "Quantidade", c => c.Int(nullable: false));
            AddColumn("dbo.OrdemItems", "ValorTotal", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Produtoes", "Nome", c => c.String());
            AddColumn("dbo.Produtoes", "Preco", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Produtoes", "Categoria", c => c.String());
            AddColumn("dbo.Produtoes", "Descricao", c => c.String());
            AddColumn("dbo.ShoppingCartDatas", "NomeDoProduto", c => c.String());
            AddColumn("dbo.ShoppingCartDatas", "PrecoUnitario", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.ShoppingCartDatas", "Quantidade", c => c.Int(nullable: false));
            AlterColumn("dbo.OrdemItems", "OrdemId", c => c.Int(nullable: false));
            CreateIndex("dbo.OrdemItems", "OrdemId");
            AddForeignKey("dbo.OrdemItems", "OrdemId", "dbo.Ordems", "Id", cascadeDelete: true);
            DropColumn("dbo.OrdemItems", "OrderID");
            DropColumn("dbo.OrdemItems", "Qty");
            DropColumn("dbo.OrdemItems", "TotalSale");
            DropColumn("dbo.Ordems", "Discriminator");
            DropColumn("dbo.Produtoes", "PName");
            DropColumn("dbo.Produtoes", "Brand");
            DropColumn("dbo.Produtoes", "UnitPrice");
            DropColumn("dbo.Produtoes", "UnitsInStock");
            DropColumn("dbo.Produtoes", "Category");
            DropColumn("dbo.Produtoes", "Description");
            DropColumn("dbo.Produtoes", "SID");
            DropColumn("dbo.Produtoes", "ROL");
            DropColumn("dbo.ShoppingCartDatas", "TempOrderID");
            DropColumn("dbo.ShoppingCartDatas", "PName");
            DropColumn("dbo.ShoppingCartDatas", "UnitPrice");
            DropColumn("dbo.ShoppingCartDatas", "Quantity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ShoppingCartDatas", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.ShoppingCartDatas", "UnitPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.ShoppingCartDatas", "PName", c => c.String());
            AddColumn("dbo.ShoppingCartDatas", "TempOrderID", c => c.Int(nullable: false));
            AddColumn("dbo.Produtoes", "ROL", c => c.Int(nullable: false));
            AddColumn("dbo.Produtoes", "SID", c => c.Int(nullable: false));
            AddColumn("dbo.Produtoes", "Description", c => c.String());
            AddColumn("dbo.Produtoes", "Category", c => c.String());
            AddColumn("dbo.Produtoes", "UnitsInStock", c => c.Int(nullable: false));
            AddColumn("dbo.Produtoes", "UnitPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Produtoes", "Brand", c => c.String());
            AddColumn("dbo.Produtoes", "PName", c => c.String());
            AddColumn("dbo.Ordems", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.OrdemItems", "TotalSale", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.OrdemItems", "Qty", c => c.Int(nullable: false));
            AddColumn("dbo.OrdemItems", "OrderID", c => c.Int(nullable: false));
            DropForeignKey("dbo.OrdemItems", "OrdemId", "dbo.Ordems");
            DropIndex("dbo.OrdemItems", new[] { "OrdemId" });
            AlterColumn("dbo.OrdemItems", "OrdemId", c => c.Int());
            DropColumn("dbo.ShoppingCartDatas", "Quantidade");
            DropColumn("dbo.ShoppingCartDatas", "PrecoUnitario");
            DropColumn("dbo.ShoppingCartDatas", "NomeDoProduto");
            DropColumn("dbo.Produtoes", "Descricao");
            DropColumn("dbo.Produtoes", "Categoria");
            DropColumn("dbo.Produtoes", "Preco");
            DropColumn("dbo.Produtoes", "Nome");
            DropColumn("dbo.OrdemItems", "ValorTotal");
            DropColumn("dbo.OrdemItems", "Quantidade");
            RenameColumn(table: "dbo.OrdemItems", name: "OrdemId", newName: "Ordem_Id");
            CreateIndex("dbo.OrdemItems", "Ordem_Id");
            AddForeignKey("dbo.OrdemItems", "Ordem_Id", "dbo.Ordems", "Id");
        }
    }
}
