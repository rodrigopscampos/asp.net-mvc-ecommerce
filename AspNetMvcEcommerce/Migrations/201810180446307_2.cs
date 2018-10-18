namespace AspNetMvcEcommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Clientes", "Bairro");
            DropColumn("dbo.Clientes", "Estado");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clientes", "Estado", c => c.String());
            AddColumn("dbo.Clientes", "Bairro", c => c.String());
        }
    }
}
