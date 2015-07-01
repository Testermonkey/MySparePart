namespace MySparePart.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class clientPartDelete : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Parts", "Category", c => c.String());
            DropColumn("dbo.Parts", "Catagory");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Parts", "Catagory", c => c.String());
            DropColumn("dbo.Parts", "Category");
        }
    }
}
