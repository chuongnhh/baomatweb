namespace chuongnh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedbv12 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AspNetComments",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CommentContent = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        UserId = c.String(maxLength: 128),
                        PostId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetPosts", t => t.PostId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.PostId);
            
            AddColumn("dbo.AspNetPosts", "PostTitle", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetComments", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetComments", "PostId", "dbo.AspNetPosts");
            DropIndex("dbo.AspNetComments", new[] { "PostId" });
            DropIndex("dbo.AspNetComments", new[] { "UserId" });
            DropColumn("dbo.AspNetPosts", "PostTitle");
            DropTable("dbo.AspNetComments");
        }
    }
}
