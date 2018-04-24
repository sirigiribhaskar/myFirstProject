namespace HRM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImageIdImageName : DbMigration
    {
        public override void Up()
        {
            
            AddColumn("dbo.AspNetUsers", "ImageName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "ImageName");
            
        }
    }
}
