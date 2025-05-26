namespace dynamics2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ganib : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DId = c.Int(nullable: false, identity: true),
                        DName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.DId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EId = c.Int(nullable: false, identity: true),
                        EName = c.String(nullable: false),
                        ESalary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EId)
                .ForeignKey("dbo.Departments", t => t.DId, cascadeDelete: true)
                .Index(t => t.DId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "DId", "dbo.Departments");
            DropIndex("dbo.Employees", new[] { "DId" });
            DropTable("dbo.Employees");
            DropTable("dbo.Departments");
        }
    }
}
