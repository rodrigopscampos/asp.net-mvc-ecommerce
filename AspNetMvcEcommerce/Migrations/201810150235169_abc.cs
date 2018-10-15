namespace AspNetMvcEcommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class abc : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FName = c.String(),
                        LName = c.String(),
                        Phone = c.String(),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        Suburb = c.String(),
                        Postcode = c.String(),
                        State = c.String(),
                        Ctype = c.String(),
                        CardNo = c.String(),
                        ExpDate = c.DateTime(nullable: false),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        DeliveryDate = c.DateTime(nullable: false),
                        CustumerId = c.Int(nullable: false),
                        Order_ProductsId = c.Int(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Customer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .Index(t => t.Customer_Id);
            
            CreateTable(
                "dbo.Order_Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderID = c.Int(nullable: false),
                        Qty = c.Int(nullable: false),
                        TotalSale = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Product_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .Index(t => t.OrderID)
                .Index(t => t.Product_Id);
            
            CreateTable(
                "dbo.Products",
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
            DropForeignKey("dbo.Order_Products", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Order_Products", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.Orders", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Order_Products", new[] { "Product_Id" });
            DropIndex("dbo.Order_Products", new[] { "OrderID" });
            DropIndex("dbo.Orders", new[] { "Customer_Id" });
            DropTable("dbo.ShoppingCartDatas");
            DropTable("dbo.Products");
            DropTable("dbo.Order_Products");
            DropTable("dbo.Orders");
            DropTable("dbo.Customers");
        }
    }
}
