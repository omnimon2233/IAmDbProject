namespace IAmDbProject.DataContexts.IAmDbProjectDbMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Wed42016 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "Event_name", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.People", "Email", c => c.String());
            AlterColumn("dbo.Items", "End_Price", c => c.Double());
            DropColumn("dbo.People", "User_Role");
        }
        
        public override void Down()
        {
            AddColumn("dbo.People", "User_Role", c => c.Int(nullable: false));
            AlterColumn("dbo.Items", "End_Price", c => c.Double(nullable: false));
            DropColumn("dbo.People", "Email");
            DropColumn("dbo.Events", "Event_name");
        }
    }
}
