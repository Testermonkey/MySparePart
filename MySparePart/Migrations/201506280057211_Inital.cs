namespace MySparePart.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inital : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Parts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemPostDate = c.DateTime(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 500),
                        Quanity = c.Int(nullable: false),
                        PartNumber = c.String(),
                        ShippingSize = c.String(),
                        PartIsHidden = c.Boolean(nullable: false),
                        PartIsLocked = c.Boolean(nullable: false),
                        PartIsDeleted = c.Boolean(nullable: false),
                        Catagory = c.String(),
                        PartOwner_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.PartOwner_Id)
                .Index(t => t.PartOwner_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
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
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.PartRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RequestTimeStamp = c.DateTime(nullable: false),
                        RequestMailedTimeStamp = c.DateTime(nullable: false),
                        RequestEmailSent = c.Boolean(nullable: false),
                        RequestMailed = c.Boolean(nullable: false),
                        ItemId = c.Int(nullable: false),
                        PartOwner_Id = c.String(maxLength: 128),
                        RequestUser_Id = c.String(maxLength: 128),
                        Part_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.PartOwner_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.RequestUser_Id)
                .ForeignKey("dbo.Parts", t => t.Part_Id)
                .Index(t => t.PartOwner_Id)
                .Index(t => t.RequestUser_Id)
                .Index(t => t.Part_Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.PartRequests", "Part_Id", "dbo.Parts");
            DropForeignKey("dbo.PartRequests", "RequestUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.PartRequests", "PartOwner_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Parts", "PartOwner_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.PartRequests", new[] { "Part_Id" });
            DropIndex("dbo.PartRequests", new[] { "RequestUser_Id" });
            DropIndex("dbo.PartRequests", new[] { "PartOwner_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Parts", new[] { "PartOwner_Id" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.PartRequests");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Parts");
        }
    }
}
