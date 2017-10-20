namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class t1 : DbMigration
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Lessons", "trainingId", "dbo.Trainings");
            DropForeignKey("dbo.Trainings", "categoryId", "dbo.Categories");
            DropForeignKey("dbo.Questions", "lessonId", "dbo.Lessons");
            DropForeignKey("dbo.Answers", "questionId", "dbo.Questions");
            DropIndex("dbo.Trainings", new[] { "categoryId" });
            DropIndex("dbo.Lessons", new[] { "trainingId" });
            DropIndex("dbo.Questions", new[] { "lessonId" });
            DropIndex("dbo.Answers", new[] { "questionId" });
            DropTable("dbo.Categories");
            DropTable("dbo.Trainings");
            DropTable("dbo.Lessons");
            DropTable("dbo.Questions");
            DropTable("dbo.Answers");
        }
    }
}
