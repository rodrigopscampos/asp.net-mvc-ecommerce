namespace AspNetMvcEcommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Produtoes", "Imagem");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Produtoes", "Imagem", c => c.String());
        }
    }
}
