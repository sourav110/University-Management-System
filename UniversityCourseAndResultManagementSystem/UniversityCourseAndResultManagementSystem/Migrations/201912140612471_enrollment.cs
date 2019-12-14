namespace UniversityCourseAndResultManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class enrollment : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ademoes", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Ademoes", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Courses", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Courses", "SemesterId", "dbo.Semesters");
            DropForeignKey("dbo.Allocations", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Allocations", "DayId", "dbo.Days");
            DropForeignKey("dbo.Allocations", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.AssignCourses", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Students", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Teachers", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Teachers", "DesignationId", "dbo.Designations");
            DropIndex("dbo.Ademoes", new[] { "DepartmentId" });
            DropIndex("dbo.Ademoes", new[] { "CourseId" });
            CreateTable(
                "dbo.Enrolls",
                c => new
                    {
                        EnrollId = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        StudentName = c.String(),
                        Email = c.String(),
                        Department = c.String(),
                        CourseId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EnrollId)
                .ForeignKey("dbo.Courses", t => t.CourseId)
                .ForeignKey("dbo.Students", t => t.StudentId)
                .Index(t => t.StudentId)
                .Index(t => t.CourseId);
            
            AddForeignKey("dbo.Courses", "DepartmentId", "dbo.Departments", "DepartmentId");
            AddForeignKey("dbo.Courses", "SemesterId", "dbo.Semesters", "SemesterId");
            AddForeignKey("dbo.Allocations", "CourseId", "dbo.Courses", "CourseId");
            AddForeignKey("dbo.Allocations", "DayId", "dbo.Days", "DayId");
            AddForeignKey("dbo.Allocations", "RoomId", "dbo.Rooms", "RoomId");
            AddForeignKey("dbo.AssignCourses", "CourseId", "dbo.Courses", "CourseId");
            AddForeignKey("dbo.Students", "DepartmentId", "dbo.Departments", "DepartmentId");
            AddForeignKey("dbo.Teachers", "DepartmentId", "dbo.Departments", "DepartmentId");
            AddForeignKey("dbo.Teachers", "DesignationId", "dbo.Designations", "DesignationId");
            DropTable("dbo.Ademoes");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.AdemoId);
            
            DropForeignKey("dbo.Teachers", "DesignationId", "dbo.Designations");
            DropForeignKey("dbo.Teachers", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Students", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.AssignCourses", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Allocations", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.Allocations", "DayId", "dbo.Days");
            DropForeignKey("dbo.Allocations", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Courses", "SemesterId", "dbo.Semesters");
            DropForeignKey("dbo.Courses", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Enrolls", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Enrolls", "CourseId", "dbo.Courses");
            DropIndex("dbo.Enrolls", new[] { "CourseId" });
            DropIndex("dbo.Enrolls", new[] { "StudentId" });
            DropTable("dbo.Enrolls");
            CreateIndex("dbo.Ademoes", "CourseId");
            CreateIndex("dbo.Ademoes", "DepartmentId");
            AddForeignKey("dbo.Teachers", "DesignationId", "dbo.Designations", "DesignationId", cascadeDelete: true);
            AddForeignKey("dbo.Teachers", "DepartmentId", "dbo.Departments", "DepartmentId", cascadeDelete: true);
            AddForeignKey("dbo.Students", "DepartmentId", "dbo.Departments", "DepartmentId", cascadeDelete: true);
            AddForeignKey("dbo.AssignCourses", "CourseId", "dbo.Courses", "CourseId", cascadeDelete: true);
            AddForeignKey("dbo.Allocations", "RoomId", "dbo.Rooms", "RoomId", cascadeDelete: true);
            AddForeignKey("dbo.Allocations", "DayId", "dbo.Days", "DayId", cascadeDelete: true);
            AddForeignKey("dbo.Allocations", "CourseId", "dbo.Courses", "CourseId", cascadeDelete: true);
            AddForeignKey("dbo.Courses", "SemesterId", "dbo.Semesters", "SemesterId", cascadeDelete: true);
            AddForeignKey("dbo.Courses", "DepartmentId", "dbo.Departments", "DepartmentId", cascadeDelete: true);
            AddForeignKey("dbo.Ademoes", "DepartmentId", "dbo.Departments", "DepartmentId");
            AddForeignKey("dbo.Ademoes", "CourseId", "dbo.Courses", "CourseId");
        }
    }
}
