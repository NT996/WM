namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyAnnotationsToProduct : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Products", "Description", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Products", "Producer", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Products", "Supplier", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Supplier", c => c.String());
            AlterColumn("dbo.Products", "Producer", c => c.String());
            AlterColumn("dbo.Products", "Description", c => c.String());
            AlterColumn("dbo.Products", "Name", c => c.String());
        }
    }
}
