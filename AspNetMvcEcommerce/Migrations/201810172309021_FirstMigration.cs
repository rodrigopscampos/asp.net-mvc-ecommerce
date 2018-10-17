namespace AspNetMvcEcommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Produtoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Preco = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Descricao = c.String(),
                        CategoriaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categorias", t => t.CategoriaId, cascadeDelete: true)
                .Index(t => t.CategoriaId);
            
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
                        CcNumero = c.String(),
                        CcValidade = c.DateTime(nullable: false),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrdemItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrdemId = c.Int(nullable: false),
                        Quantidade = c.Int(nullable: false),
                        ValorTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ordems", t => t.OrdemId, cascadeDelete: true)
                .Index(t => t.OrdemId);
            
            CreateTable(
                "dbo.Ordems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DataDeCriacao = c.DateTime(nullable: false),
                        DataDeEntrega = c.DateTime(nullable: false),
                        ClienteId = c.Int(nullable: false),
                        ItensId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clientes", t => t.ClienteId, cascadeDelete: true)
                .Index(t => t.ClienteId);
            
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
        
        public override void Down()
        {
            DropForeignKey("dbo.OrdemItems", "OrdemId", "dbo.Ordems");
            DropForeignKey("dbo.Ordems", "ClienteId", "dbo.Clientes");
            DropForeignKey("dbo.Produtoes", "CategoriaId", "dbo.Categorias");
            DropIndex("dbo.Ordems", new[] { "ClienteId" });
            DropIndex("dbo.OrdemItems", new[] { "OrdemId" });
            DropIndex("dbo.Produtoes", new[] { "CategoriaId" });
            DropTable("dbo.CarrinhoDeComprasItems");
            DropTable("dbo.Ordems");
            DropTable("dbo.OrdemItems");
            DropTable("dbo.Clientes");
            DropTable("dbo.Produtoes");
            DropTable("dbo.Categorias");
        }
    }
}
