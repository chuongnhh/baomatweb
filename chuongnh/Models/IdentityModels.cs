using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using chuongnh.CodeHelper;

namespace chuongnh.Models
{
    [Table("AspNetCategories")]
    public class ApplicationCategory
    {
        public ApplicationCategory()
        {
            Id = GuidComb.GenerateComb();
            Posts = new List<ApplicationPost>();
            CreatedDate = DateTime.Now;
            UpdatedDate = DateTime.Now;
        }
        [Key]
        public Guid Id { get; set; }
        [Display(Name ="Tên chuyên mục")]
        public string CategoryName { get; set; }

        public string CategoryContent { get; set; }
        [Display(Name ="Thẻ tiêu đề")]
        public string MetaTitle { get; set; }
        // manage 
        [Display(Name ="Người khởi tạo")]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }

        [Display(Name ="Ngày khởi tạo")]
        public DateTime CreatedDate { get; set; }
        [Display(Name ="Ngày cập nhật")]
        public DateTime UpdatedDate { get; set; }

        public virtual ICollection<ApplicationPost> Posts { get; set; }
    }

    [Table("AspNetPosts")]
    public class ApplicationPost
    {
        public ApplicationPost()
        {
            Id = GuidComb.GenerateComb();
            Tags = new List<ApplictionTag>();
            CreatedDate = DateTime.Now;
            UpdatedDate = DateTime.Now;
            Comments = new List<ApplicationComment>();
            Image = "/Uploads/Posts/def.jpg";
        }
        [Key]
        public Guid Id { get; set; }

        // manage 
        public string UserId { get; set; }
        public string PostTitle { get; set; }

        public string PostContent { get; set; }

        public string Decsription { get; set; }
        public string Image { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public virtual ICollection<ApplictionTag> Tags { get; set; }

        public Guid CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual ApplicationCategory Category { get; set; }

        public virtual ICollection<ApplicationComment> Comments { get; set; }
    }

    [Table("AspNetTags")]
    public class ApplictionTag
    {
        public ApplictionTag()
        {
            Id = GuidComb.GenerateComb();
            Posts = new List<ApplicationPost>();
            CreatedDate = DateTime.Now;
            UpdatedDate = DateTime.Now;
        }
        [Key]
        public Guid Id { get; set; }

        // manage 
        public string UserId { get; set; }
        public string  TagContent { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public virtual ICollection<ApplicationPost> Posts { get; set; }
    }

    [Table("AspNetComments")]
    public class ApplicationComment
    {
        [Key]
        public Guid Id { get; set; }
        public string CommentContent { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }

        public Guid PostId { get; set; }
        [ForeignKey("PostId")]
        public virtual ApplicationPost Post { get; set; }

        public Guid CommentId { get; set; }
        [ForeignKey("CommentId")]
        public virtual ApplicationComment Comment { get; set; }
    }

    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            Categories = new List<ApplicationCategory>();
            Posts = new List<ApplicationPost>();
            Tags = new List<ApplictionTag>();
            Comments = new List<ApplicationComment>();

        }
        [Display(Name ="Tên người dùng")]
        public string FullName { get; set; }

        public virtual ICollection<ApplicationCategory> Categories { get; set; }
        public virtual ICollection<ApplicationPost> Posts { get; set; }
        public virtual ICollection<ApplictionTag> Tags { get; set; }
        public virtual ICollection<ApplicationComment> Comments { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public virtual DbSet<ApplicationCategory> Categories { get; set; }
        public virtual DbSet<ApplicationPost> Posts { get; set; }
        public virtual DbSet<ApplictionTag> Tags { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationPost>()
               .HasMany<ApplictionTag>(s => s.Tags)
               .WithMany(c => c.Posts)
               .Map(cs =>
               {
                   cs.MapLeftKey("TagId");
                   cs.MapRightKey("PostId");
                   cs.ToTable("AspNetPostTags");
               });
        }
    }
}