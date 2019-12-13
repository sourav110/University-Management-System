namespace UniversityCourseAndResultManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ademoes",
                c => new
                    {
                        AdemoId = c.Int(nullable: false, identity: true),
                        DepartmentId = c.Int(),
                        CourseId = c.Int(),
                        CourseName = c.String(),
                        Credit = c.String(),
                    })
                .PrimaryKey(t => t.AdemoId)
                .ForeignKey("dbo.Courses", t => t.CourseId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId)
                .Index(t => t.DepartmentId)
                .Index(t => t.CourseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ademoes", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Ademoes", "CourseId", "dbo.Courses");
            DropIndex("dbo.Ademoes", new[] { "CourseId" });
            DropIndex("dbo.Ademoes", new[] { "DepartmentId" });
            DropTable("dbo.Ademoes");
        }
    }
}
