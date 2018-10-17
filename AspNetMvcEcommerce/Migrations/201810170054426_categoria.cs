namespace AspNetMvcEcommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class categoria : DbMigration
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
            
            AddColumn("dbo.Produtoes", "CategoriaId", c => c.Int(nullable: false));
            CreateIndex("dbo.Produtoes", "CategoriaId");
            AddForeignKey("dbo.Produtoes", "CategoriaId", "dbo.Categorias", "Id", cascadeDelete: true);
            DropColumn("dbo.Produtoes", "Categoria");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Produtoes", "Categoria", c => c.String());
            DropForeignKey("dbo.Produtoes", "CategoriaId", "dbo.Categorias");
            DropIndex("dbo.Produtoes", new[] { "CategoriaId" });
            DropColumn("dbo.Produtoes", "CategoriaId");
            DropTable("dbo.Categorias");
        }
    }
}
