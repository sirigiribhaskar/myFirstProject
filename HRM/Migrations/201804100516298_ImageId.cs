namespace HRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImageId : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "ImageId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "ImageId", c => c.Int(nullable: false));
        }
    }
}
