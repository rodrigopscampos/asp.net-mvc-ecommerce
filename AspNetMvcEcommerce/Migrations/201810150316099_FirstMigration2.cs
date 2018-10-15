namespace AspNetMvcEcommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Phone = c.String(),
                        Endereco = c.String(),
                        Bairro = c.String(),
                        CEP = c.String(),
                        Estado = c.String(),
                        Ctype = c.String(),
                        CcNumero = c.String(),
                        CcValidade = c.DateTime(nullable: false),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ordems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DataDeCriacao = c.DateTime(nullable: false),
                        DataDeEntrega = c.DateTime(nullable: false),
                        ClienteId = c.Int(nullable: false),
                        ItensId = c.Int(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clientes", t => t.ClienteId, cascadeDelete: true)
                .Index(t => t.ClienteId);
            
            CreateTable(
                "dbo.OrdemItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderID = c.Int(nullable: false),
                        Qty = c.Int(nullable: false),
                        TotalSale = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Ordem_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ordems", t => t.Ordem_Id)
                .Index(t => t.Ordem_Id);
            
            CreateTable(
                "dbo.Produtoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PName = c.String(),
                        Brand = c.String(),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnitsInStock = c.Int(nullable: false),
                        Category = c.String(),
                        Description = c.String(),
                        SID = c.Int(nullable: false),
                        ROL = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ShoppingCartDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TempOrderID = c.Int(nullable: false),
                        PName = c.String(),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrdemItems", "Ordem_Id", "dbo.Ordems");
            DropForeignKey("dbo.Ordems", "ClienteId", "dbo.Clientes");
            DropIndex("dbo.OrdemItems", new[] { "Ordem_Id" });
            DropIndex("dbo.Ordems", new[] { "ClienteId" });
            DropTable("dbo.ShoppingCartDatas");
            DropTable("dbo.Produtoes");
            DropTable("dbo.OrdemItems");
            DropTable("dbo.Ordems");
            DropTable("dbo.Clientes");
        }
    }
}
