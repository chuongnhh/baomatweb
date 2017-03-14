namespace chuongnh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedbv11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetCategories", "CategoryContent", c => c.String());
            AddColumn("dbo.AspNetPosts", "PostContent", c => c.String());
            AddColumn("dbo.AspNetTags", "TagContent", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetTags", "TagContent");
            DropColumn("dbo.AspNetPosts", "PostContent");
            DropColumn("dbo.AspNetCategories", "CategoryContent");
        }
    }
}
