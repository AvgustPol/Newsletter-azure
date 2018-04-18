namespace Newsletter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class try20addisSub : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "isSub", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "isSub");
        }
    }
}
