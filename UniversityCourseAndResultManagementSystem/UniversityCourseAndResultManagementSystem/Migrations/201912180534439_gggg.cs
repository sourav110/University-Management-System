namespace UniversityCourseAndResultManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gggg : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Results", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Results", "GradeId", "dbo.Grades");
            DropForeignKey("dbo.Results", "StudentId", "dbo.Students");
            DropIndex("dbo.Results", new[] { "StudentId" });
            DropIndex("dbo.Results", new[] { "CourseId" });
            DropIndex("dbo.Results", new[] { "GradeId" });
            DropTable("dbo.Results");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Results",
                c => new
                    {
                        ResultId = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        GradeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ResultId);
            
            CreateIndex("dbo.Results", "GradeId");
            CreateIndex("dbo.Results", "CourseId");
            CreateIndex("dbo.Results", "StudentId");
            AddForeignKey("dbo.Results", "StudentId", "dbo.Students", "StudentId");
            AddForeignKey("dbo.Results", "GradeId", "dbo.Grades", "GradeId");
            AddForeignKey("dbo.Results", "CourseId", "dbo.Courses", "CourseId");
        }
    }
}
