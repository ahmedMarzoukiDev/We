namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Trainings", "categoryId", "dbo.Categories");
            DropIndex("dbo.Trainings", new[] { "categoryId" });
            DropColumn("dbo.Trainings", "editorId");
            DropColumn("dbo.Trainings", "categoryId");
            DropTable("dbo.Categories");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        categoryId = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.categoryId);
            
            AddColumn("dbo.Trainings", "categoryId", c => c.Int(nullable: false));
            AddColumn("dbo.Trainings", "editorId", c => c.Int(nullable: false));
            CreateIndex("dbo.Trainings", "categoryId");
            AddForeignKey("dbo.Trainings", "categoryId", "dbo.Categories", "categoryId", cascadeDelete: true);
        }
    }
}
