namespace chuongnh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedbv10 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AspNetCategories",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CategoryName = c.String(),
                        MetaTitle = c.String(),
                        UserId = c.String(maxLength: 128),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetPosts",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserId = c.String(maxLength: 128),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        CategoryId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetCategories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.AspNetTags",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserId = c.String(maxLength: 128),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetPostTags",
                c => new
                    {
                        TagId = c.Guid(nullable: false),
                        PostId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.TagId, t.PostId })
                .ForeignKey("dbo.AspNetPosts", t => t.TagId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetTags", t => t.PostId, cascadeDelete: true)
                .Index(t => t.TagId)
                .Index(t => t.PostId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetCategories", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetPosts", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetPostTags", "PostId", "dbo.AspNetTags");
            DropForeignKey("dbo.AspNetPostTags", "TagId", "dbo.AspNetPosts");
            DropForeignKey("dbo.AspNetTags", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetPosts", "CategoryId", "dbo.AspNetCategories");
            DropIndex("dbo.AspNetPostTags", new[] { "PostId" });
            DropIndex("dbo.AspNetPostTags", new[] { "TagId" });
            DropIndex("dbo.AspNetTags", new[] { "UserId" });
            DropIndex("dbo.AspNetPosts", new[] { "CategoryId" });
            DropIndex("dbo.AspNetPosts", new[] { "UserId" });
            DropIndex("dbo.AspNetCategories", new[] { "UserId" });
            DropTable("dbo.AspNetPostTags");
            DropTable("dbo.AspNetTags");
            DropTable("dbo.AspNetPosts");
            DropTable("dbo.AspNetCategories");
        }
    }
}
