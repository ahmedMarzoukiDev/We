namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class te : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trainings", "editorId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Trainings", "editorId");
        }
    }
}
