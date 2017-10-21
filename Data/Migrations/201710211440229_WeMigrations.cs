namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WeMigrations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        answerId = c.Int(nullable: false, identity: true),
                        description = c.String(),
                        editorId = c.Int(nullable: false),
                        isTrue = c.Boolean(nullable: false),
                        questionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.answerId)
                .ForeignKey("dbo.Questions", t => t.questionId, cascadeDelete: true)
                .Index(t => t.questionId);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        questionId = c.Int(nullable: false, identity: true),
                        title = c.String(),
                        description = c.String(),
                        editorId = c.Int(nullable: false),
                        lessonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.questionId)
                .ForeignKey("dbo.Lessons", t => t.lessonId, cascadeDelete: true)
                .Index(t => t.lessonId);
            
            CreateTable(
                "dbo.Lessons",
                c => new
                    {
                        lessonId = c.Int(nullable: false, identity: true),
                        title = c.String(),
                        description = c.String(),
                        estimatedTime = c.Int(nullable: false),
                        dateAdded = c.DateTime(nullable: false),
                        editorId = c.Int(nullable: false),
                        trainingId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.lessonId)
                .ForeignKey("dbo.Trainings", t => t.trainingId, cascadeDelete: true)
                .Index(t => t.trainingId);
            
            CreateTable(
                "dbo.Trainings",
                c => new
                    {
                        trainingId = c.Int(nullable: false, identity: true),
                        title = c.String(),
                        description = c.String(),
                        estimatedTime = c.Int(nullable: false),
                        dateAdded = c.DateTime(nullable: false),
                        difficultyValue = c.Int(nullable: false),
                        difficultyDescription = c.String(),
                        editorId = c.Int(nullable: false),
                        categoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.trainingId)
                .ForeignKey("dbo.Categories", t => t.categoryId, cascadeDelete: true)
                .Index(t => t.categoryId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        categoryId = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.categoryId);
            
            CreateTable(
                "dbo.Appointements",
                c => new
                    {
                        AppointementId = c.Int(nullable: false, identity: true),
                        appoinDate = c.DateTime(nullable: false),
                        appoinTime = c.Time(nullable: false, precision: 7),
                        state = c.Boolean(nullable: false),
                        appoinAddress = c.String(),
                        mcase_CaseId = c.Int(),
                        physician_PhysicianId = c.Int(),
                    })
                .PrimaryKey(t => t.AppointementId)
                .ForeignKey("dbo.Cases", t => t.mcase_CaseId)
                .ForeignKey("dbo.Physicians", t => t.physician_PhysicianId)
                .Index(t => t.mcase_CaseId)
                .Index(t => t.physician_PhysicianId);
            
            CreateTable(
                "dbo.Cases",
                c => new
                    {
                        CaseId = c.Int(nullable: false, identity: true),
                        physicianName = c.String(),
                        decription = c.String(),
                        titre = c.String(),
                        state = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CaseId);
            
            CreateTable(
                "dbo.Physicians",
                c => new
                    {
                        PhysicianId = c.Int(nullable: false, identity: true),
                        field = c.Int(nullable: false),
                        nbCases = c.Int(nullable: false),
                        localisation = c.String(),
                    })
                .PrimaryKey(t => t.PhysicianId);
            
            CreateTable(
                "dbo.Availabilities",
                c => new
                    {
                        AvailabilityId = c.Int(nullable: false, identity: true),
                        availDate = c.DateTime(nullable: false),
                        availTime = c.Time(nullable: false, precision: 7),
                        physicians_PhysicianId = c.Int(),
                    })
                .PrimaryKey(t => t.AvailabilityId)
                .ForeignKey("dbo.Physicians", t => t.physicians_PhysicianId)
                .Index(t => t.physicians_PhysicianId);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventID = c.Int(nullable: false, identity: true),
                        EventName = c.String(),
                        Description = c.String(),
                        Address = c.String(),
                        DateStart = c.DateTime(nullable: false),
                        DateEnd = c.DateTime(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EventID);
            
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        BookingID = c.Int(nullable: false, identity: true),
                        BookDate = c.DateTime(nullable: false),
                        EventId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookingID)
                .ForeignKey("dbo.Events", t => t.EventId, cascadeDelete: true)
                .Index(t => t.EventId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "EventId", "dbo.Events");
            DropForeignKey("dbo.Availabilities", "physicians_PhysicianId", "dbo.Physicians");
            DropForeignKey("dbo.Appointements", "physician_PhysicianId", "dbo.Physicians");
            DropForeignKey("dbo.Appointements", "mcase_CaseId", "dbo.Cases");
            DropForeignKey("dbo.Lessons", "trainingId", "dbo.Trainings");
            DropForeignKey("dbo.Trainings", "categoryId", "dbo.Categories");
            DropForeignKey("dbo.Questions", "lessonId", "dbo.Lessons");
            DropForeignKey("dbo.Answers", "questionId", "dbo.Questions");
            DropIndex("dbo.Bookings", new[] { "EventId" });
            DropIndex("dbo.Availabilities", new[] { "physicians_PhysicianId" });
            DropIndex("dbo.Appointements", new[] { "physician_PhysicianId" });
            DropIndex("dbo.Appointements", new[] { "mcase_CaseId" });
            DropIndex("dbo.Trainings", new[] { "categoryId" });
            DropIndex("dbo.Lessons", new[] { "trainingId" });
            DropIndex("dbo.Questions", new[] { "lessonId" });
            DropIndex("dbo.Answers", new[] { "questionId" });
            DropTable("dbo.Bookings");
            DropTable("dbo.Events");
            DropTable("dbo.Availabilities");
            DropTable("dbo.Physicians");
            DropTable("dbo.Cases");
            DropTable("dbo.Appointements");
            DropTable("dbo.Categories");
            DropTable("dbo.Trainings");
            DropTable("dbo.Lessons");
            DropTable("dbo.Questions");
            DropTable("dbo.Answers");
        }
    }
}
