namespace StudentWebMarket.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cat : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "Name", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Categories", "Name", c => c.String());
        }
    }
}
