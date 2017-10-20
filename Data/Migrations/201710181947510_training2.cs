namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class training2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Trainings", "title", c => c.String(nullable: false));
            AlterColumn("dbo.Trainings", "description", c => c.String(nullable: false));
            AlterColumn("dbo.Trainings", "difficultyDescription", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Trainings", "difficultyDescription", c => c.String());
            AlterColumn("dbo.Trainings", "description", c => c.String());
            AlterColumn("dbo.Trainings", "title", c => c.String());
        }
    }
}
