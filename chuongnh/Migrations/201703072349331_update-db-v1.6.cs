namespace chuongnh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedbv16 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetPosts", "Decsription", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetPosts", "Decsription");
        }
    }
}
