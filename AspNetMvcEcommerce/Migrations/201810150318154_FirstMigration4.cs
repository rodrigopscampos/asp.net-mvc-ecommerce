namespace AspNetMvcEcommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration4 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Clientes", "Ctype");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clientes", "Ctype", c => c.String());
        }
    }
}
