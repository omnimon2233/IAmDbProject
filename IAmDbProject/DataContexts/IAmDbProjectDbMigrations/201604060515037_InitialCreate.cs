namespace IAmDbProject.DataContexts.IAmDbProjectDbMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Donors",
                c => new
                    {
                        Donor_Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Address = c.String(nullable: false, maxLength: 50),
                        City = c.String(nullable: false, maxLength: 30),
                        State = c.Int(nullable: false),
                        Phone = c.String(nullable: false),
                        Receipt_Required_Bool = c.Int(nullable: false),
                        Person_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Donor_Id)
                .ForeignKey("dbo.People", t => t.Person_Id)
                .Index(t => t.Person_Id);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Item_Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 40),
                        Expected_Sale_Value = c.Double(nullable: false),
                        Description = c.String(nullable: false, maxLength: 255),
                        Start_Price = c.Double(nullable: false),
                        End_Price = c.Double(nullable: false),
                        Min_Increment = c.Double(nullable: false),
                        Buyout_Price = c.Double(nullable: false),
                        Donor_Id = c.Int(nullable: false),
                        Event_Id = c.Int(),
                        Person_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Item_Id)
                .ForeignKey("dbo.Donors", t => t.Donor_Id, cascadeDelete: true)
                .ForeignKey("dbo.Events", t => t.Event_Id)
                .ForeignKey("dbo.People", t => t.Person_Id)
                .Index(t => t.Name, name: "Idx_item_name")
                .Index(t => t.Donor_Id)
                .Index(t => t.Event_Id)
                .Index(t => t.Person_Id);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Event_Id = c.Int(nullable: false, identity: true),
                        Address = c.String(nullable: false, maxLength: 50),
                        City = c.String(nullable: false, maxLength: 30),
                        State = c.Int(nullable: false),
                        County = c.String(nullable: false, maxLength: 20),
                        Date = c.DateTime(nullable: false),
                        Event_Type = c.String(nullable: false),
                        Event_Total = c.Double(nullable: false),
                        Event_Close = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Event_Id);
            
            CreateTable(
                "dbo.Item_In_Transaction",
                c => new
                    {
                        Transaction_Id = c.Int(nullable: false),
                        Item_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Transaction_Id, t.Item_Id })
                .ForeignKey("dbo.Items", t => t.Item_Id, cascadeDelete: true)
                .ForeignKey("dbo.Transactions", t => t.Transaction_Id, cascadeDelete: true)
                .Index(t => t.Transaction_Id)
                .Index(t => t.Item_Id);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        Transaction_Id = c.Int(nullable: false, identity: true),
                        Credit_Card_Number = c.Int(nullable: false),
                        Zip = c.String(maxLength: 5),
                        Cvv2_Code = c.Int(nullable: false),
                        Receipt_Bool = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Transaction_Id);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Person_Id = c.Int(nullable: false, identity: true),
                        First_Name = c.String(nullable: false, maxLength: 25),
                        Last_Name = c.String(nullable: false, maxLength: 25),
                        Address1 = c.String(nullable: false, maxLength: 255),
                        Address2 = c.String(maxLength: 255),
                        City = c.String(nullable: false, maxLength: 30),
                        State = c.Int(nullable: false),
                        Zip = c.String(maxLength: 5),
                        Phone = c.String(nullable: false),
                        Waiver_Signed = c.Int(nullable: false),
                        Deceased_Bool = c.Int(nullable: false),
                        User_Role = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Person_Id)
                .Index(t => new { t.First_Name, t.Last_Name }, name: "Idx_person_full_name")
                .Index(t => t.Last_Name, name: "Idx_person_last_name")
                .Index(t => t.Status, name: "Idx_person_status");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Donors", "Person_Id", "dbo.People");
            DropForeignKey("dbo.Items", "Person_Id", "dbo.People");
            DropForeignKey("dbo.Item_In_Transaction", "Transaction_Id", "dbo.Transactions");
            DropForeignKey("dbo.Item_In_Transaction", "Item_Id", "dbo.Items");
            DropForeignKey("dbo.Items", "Event_Id", "dbo.Events");
            DropForeignKey("dbo.Items", "Donor_Id", "dbo.Donors");
            DropIndex("dbo.People", "Idx_person_status");
            DropIndex("dbo.People", "Idx_person_last_name");
            DropIndex("dbo.People", "Idx_person_full_name");
            DropIndex("dbo.Item_In_Transaction", new[] { "Item_Id" });
            DropIndex("dbo.Item_In_Transaction", new[] { "Transaction_Id" });
            DropIndex("dbo.Items", new[] { "Person_Id" });
            DropIndex("dbo.Items", new[] { "Event_Id" });
            DropIndex("dbo.Items", new[] { "Donor_Id" });
            DropIndex("dbo.Items", "Idx_item_name");
            DropIndex("dbo.Donors", new[] { "Person_Id" });
            DropTable("dbo.People");
            DropTable("dbo.Transactions");
            DropTable("dbo.Item_In_Transaction");
            DropTable("dbo.Events");
            DropTable("dbo.Items");
            DropTable("dbo.Donors");
        }
    }
}
