namespace chuongnh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedbv17 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetPosts", "Image", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetPosts", "Image");
        }
    }
}
