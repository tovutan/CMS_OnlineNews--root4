namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OnlineNews2018 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        URL = c.String(nullable: false, maxLength: 100, unicode: false),
                        ImageURL = c.String(),
                        Description = c.String(),
                        ParentId = c.Int(),
                        Priority = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        IsShow = c.Boolean(nullable: false),
                        CustomLayout = c.String(),
                        SeoTitle = c.String(maxLength: 250),
                        SeoKeyword = c.String(),
                        SeoDescription = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(),
                        CreateBy = c.String(nullable: false, maxLength: 128),
                        UpdateBy = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.ParentId)
                .ForeignKey("dbo.User", t => t.CreateBy)
                .ForeignKey("dbo.User", t => t.UpdateBy)
                .Index(t => t.Name)
                .Index(t => t.URL)
                .Index(t => t.ParentId)
                .Index(t => t.CreateBy)
                .Index(t => t.UpdateBy);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(),
                        CreateBy = c.String(maxLength: 128),
                        UpdateBy = c.String(maxLength: 128),
                        FullName = c.String(maxLength: 50),
                        ImageURL = c.String(),
                        AuthorName = c.String(),
                        Description = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.CreateBy)
                .ForeignKey("dbo.User", t => t.UpdateBy)
                .Index(t => t.CreateBy)
                .Index(t => t.UpdateBy)
                .Index(t => t.UserName, name: "UserNameIndex");
            
            CreateTable(
                "dbo.UserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.LoginProvider, t.ProviderKey })
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.Role", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.Post",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 250),
                        URL = c.String(nullable: false, maxLength: 250, unicode: false),
                        ShortDesc = c.String(nullable: false),
                        FullDesc = c.String(nullable: false),
                        ImageURL = c.String(),
                        View = c.Int(nullable: false),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        IsShow = c.Boolean(nullable: false),
                        IsHot = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        IsAllowComment = c.Boolean(nullable: false),
                        IsDraft = c.Boolean(nullable: false),
                        SeoTitle = c.String(maxLength: 250),
                        SeoKeyword = c.String(),
                        SeoDescription = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(),
                        CreateBy = c.String(nullable: false, maxLength: 128),
                        UpdateBy = c.String(maxLength: 128),
                        PublicDate = c.DateTime(),
                        PublicBy = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.CreateBy)
                .ForeignKey("dbo.User", t => t.PublicBy)
                .ForeignKey("dbo.User", t => t.UpdateBy)
                .Index(t => t.URL)
                .Index(t => t.CreateBy)
                .Index(t => t.UpdateBy)
                .Index(t => t.PublicBy);
            
            CreateTable(
                "dbo.Tag",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        URL = c.String(nullable: false, maxLength: 250, unicode: false),
                        ImageURL = c.String(),
                        Link = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        IsShow = c.Boolean(nullable: false),
                        PinInSearch = c.Boolean(nullable: false),
                        SeoTitle = c.String(maxLength: 250),
                        SeoKeyword = c.String(),
                        SeoDescription = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(),
                        CreateBy = c.String(nullable: false, maxLength: 128),
                        UpdateBy = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.CreateBy)
                .ForeignKey("dbo.User", t => t.UpdateBy)
                .Index(t => t.Name)
                .Index(t => t.URL)
                .Index(t => t.CreateBy)
                .Index(t => t.UpdateBy);
            
            CreateTable(
                "dbo.Log",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Message = c.String(nullable: false, maxLength: 250),
                        Type = c.Int(nullable: false),
                        DataAccess = c.String(),
                        Description = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        CreateBy = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.CreateBy, cascadeDelete: true)
                .Index(t => t.CreateBy);
            
            CreateTable(
                "dbo.Navigation",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Priority = c.Int(nullable: false),
                        CategoryId = c.Int(),
                        Title = c.String(maxLength: 100),
                        IsShow = c.Boolean(nullable: false),
                        CustomURL = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(),
                        CreateBy = c.String(nullable: false, maxLength: 128),
                        UpdateBy = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.CategoryId)
                .ForeignKey("dbo.User", t => t.CreateBy)
                .ForeignKey("dbo.User", t => t.UpdateBy)
                .Index(t => t.CategoryId)
                .Index(t => t.CreateBy)
                .Index(t => t.UpdateBy);
            
            CreateTable(
                "dbo.Setting",
                c => new
                    {
                        Key = c.String(nullable: false, maxLength: 50, unicode: false),
                        Value = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        UpdateDate = c.DateTime(),
                        UpdateBy = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Key)
                .ForeignKey("dbo.User", t => t.UpdateBy)
                .Index(t => t.UpdateBy);
            
            CreateTable(
                "dbo.Post_Category_Mapping",
                c => new
                    {
                        PostId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PostId, t.CategoryId })
                .ForeignKey("dbo.Post", t => t.PostId, cascadeDelete: true)
                .ForeignKey("dbo.Category", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.PostId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Post_Tag_Mapping",
                c => new
                    {
                        PostId = c.Int(nullable: false),
                        TagId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PostId, t.TagId })
                .ForeignKey("dbo.Post", t => t.PostId, cascadeDelete: true)
                .ForeignKey("dbo.Tag", t => t.TagId, cascadeDelete: true)
                .Index(t => t.PostId)
                .Index(t => t.TagId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Setting", "UpdateBy", "dbo.User");
            DropForeignKey("dbo.Navigation", "UpdateBy", "dbo.User");
            DropForeignKey("dbo.Navigation", "CreateBy", "dbo.User");
            DropForeignKey("dbo.Navigation", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.Log", "CreateBy", "dbo.User");
            DropForeignKey("dbo.Category", "UpdateBy", "dbo.User");
            DropForeignKey("dbo.Post", "UpdateBy", "dbo.User");
            DropForeignKey("dbo.Post_Tag_Mapping", "TagId", "dbo.Tag");
            DropForeignKey("dbo.Post_Tag_Mapping", "PostId", "dbo.Post");
            DropForeignKey("dbo.Tag", "UpdateBy", "dbo.User");
            DropForeignKey("dbo.Tag", "CreateBy", "dbo.User");
            DropForeignKey("dbo.Post", "PublicBy", "dbo.User");
            DropForeignKey("dbo.Post", "CreateBy", "dbo.User");
            DropForeignKey("dbo.Post_Category_Mapping", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.Post_Category_Mapping", "PostId", "dbo.Post");
            DropForeignKey("dbo.Category", "CreateBy", "dbo.User");
            DropForeignKey("dbo.User", "UpdateBy", "dbo.User");
            DropForeignKey("dbo.UserRole", "UserId", "dbo.User");
            DropForeignKey("dbo.UserRole", "RoleId", "dbo.Role");
            DropForeignKey("dbo.UserLogin", "UserId", "dbo.User");
            DropForeignKey("dbo.User", "CreateBy", "dbo.User");
            DropForeignKey("dbo.UserClaim", "UserId", "dbo.User");
            DropForeignKey("dbo.Category", "ParentId", "dbo.Category");
            DropIndex("dbo.Post_Tag_Mapping", new[] { "TagId" });
            DropIndex("dbo.Post_Tag_Mapping", new[] { "PostId" });
            DropIndex("dbo.Post_Category_Mapping", new[] { "CategoryId" });
            DropIndex("dbo.Post_Category_Mapping", new[] { "PostId" });
            DropIndex("dbo.Setting", new[] { "UpdateBy" });
            DropIndex("dbo.Navigation", new[] { "UpdateBy" });
            DropIndex("dbo.Navigation", new[] { "CreateBy" });
            DropIndex("dbo.Navigation", new[] { "CategoryId" });
            DropIndex("dbo.Log", new[] { "CreateBy" });
            DropIndex("dbo.Tag", new[] { "UpdateBy" });
            DropIndex("dbo.Tag", new[] { "CreateBy" });
            DropIndex("dbo.Tag", new[] { "URL" });
            DropIndex("dbo.Tag", new[] { "Name" });
            DropIndex("dbo.Post", new[] { "PublicBy" });
            DropIndex("dbo.Post", new[] { "UpdateBy" });
            DropIndex("dbo.Post", new[] { "CreateBy" });
            DropIndex("dbo.Post", new[] { "URL" });
            DropIndex("dbo.Role", "RoleNameIndex");
            DropIndex("dbo.UserRole", new[] { "RoleId" });
            DropIndex("dbo.UserRole", new[] { "UserId" });
            DropIndex("dbo.UserLogin", new[] { "UserId" });
            DropIndex("dbo.UserClaim", new[] { "UserId" });
            DropIndex("dbo.User", "UserNameIndex");
            DropIndex("dbo.User", new[] { "UpdateBy" });
            DropIndex("dbo.User", new[] { "CreateBy" });
            DropIndex("dbo.Category", new[] { "UpdateBy" });
            DropIndex("dbo.Category", new[] { "CreateBy" });
            DropIndex("dbo.Category", new[] { "ParentId" });
            DropIndex("dbo.Category", new[] { "URL" });
            DropIndex("dbo.Category", new[] { "Name" });
            DropTable("dbo.Post_Tag_Mapping");
            DropTable("dbo.Post_Category_Mapping");
            DropTable("dbo.Setting");
            DropTable("dbo.Navigation");
            DropTable("dbo.Log");
            DropTable("dbo.Tag");
            DropTable("dbo.Post");
            DropTable("dbo.Role");
            DropTable("dbo.UserRole");
            DropTable("dbo.UserLogin");
            DropTable("dbo.UserClaim");
            DropTable("dbo.User");
            DropTable("dbo.Category");
        }
    }
}
