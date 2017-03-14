namespace chuongnh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedbv15 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetComments", "CommentId", c => c.Guid(nullable: false));
            CreateIndex("dbo.AspNetComments", "CommentId");
            AddForeignKey("dbo.AspNetComments", "CommentId", "dbo.AspNetComments", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetComments", "CommentId", "dbo.AspNetComments");
            DropIndex("dbo.AspNetComments", new[] { "CommentId" });
            DropColumn("dbo.AspNetComments", "CommentId");
        }
    }
}
