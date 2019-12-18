namespace UniversityCourseAndResultManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class clone : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Allocations",
                c => new
                    {
                        AllocationId = c.Int(nullable: false, identity: true),
                        DepartmentId = c.Int(),
                        CourseId = c.Int(),
                        RoomId = c.Int(nullable: false),
                        DayId = c.Int(nullable: false),
                        FromTime = c.String(),
                        ToTime = c.String(),
                    })
                .PrimaryKey(t => t.AllocationId)
                .ForeignKey("dbo.Courses", t => t.CourseId)
                .ForeignKey("dbo.Days", t => t.DayId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId)
                .ForeignKey("dbo.Rooms", t => t.RoomId)
                .Index(t => t.DepartmentId)
                .Index(t => t.CourseId)
                .Index(t => t.RoomId)
                .Index(t => t.DayId);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseId = c.Int(nullable: false, identity: true),
                        CourseCode = c.String(nullable: false, maxLength: 8000, unicode: false),
                        CourseName = c.String(nullable: false, maxLength: 8000, unicode: false),
                        CourseCredit = c.Single(nullable: false),
                        Description = c.String(),
                        DepartmentId = c.Int(nullable: false),
                        SemesterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId)
                .ForeignKey("dbo.Semesters", t => t.SemesterId)
                .Index(t => t.DepartmentId)
                .Index(t => t.SemesterId);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        DepartmentCode = c.String(nullable: false, maxLength: 7, unicode: false),
                        DepartmentName = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Semesters",
                c => new
                    {
                        SemesterId = c.Int(nullable: false, identity: true),
                        SemesterNo = c.String(),
                    })
                .PrimaryKey(t => t.SemesterId);
            
            CreateTable(
                "dbo.Days",
                c => new
                    {
                        DayId = c.Int(nullable: false, identity: true),
                        DayName = c.String(),
                    })
                .PrimaryKey(t => t.DayId);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        RoomId = c.Int(nullable: false, identity: true),
                        RoomNo = c.String(),
                    })
                .PrimaryKey(t => t.RoomId);
            
            CreateTable(
                "dbo.AssignCourses",
                c => new
                    {
                        AssignId = c.Int(nullable: false, identity: true),
                        DepartmentId = c.Int(nullable: false),
                        TeacherId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AssignId)
                .ForeignKey("dbo.Courses", t => t.CourseId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId)
                .ForeignKey("dbo.Teachers", t => t.TeacherId)
                .Index(t => t.DepartmentId)
                .Index(t => t.TeacherId)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        TeacherId = c.Int(nullable: false, identity: true),
                        TeacherName = c.String(nullable: false, maxLength: 50),
                        Address = c.String(),
                        Email = c.String(nullable: false, maxLength: 8000, unicode: false),
                        ContactNo = c.String(nullable: false),
                        DesignationId = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        CreditToBeTaken = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.TeacherId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId)
                .ForeignKey("dbo.Designations", t => t.DesignationId)
                .Index(t => t.DesignationId)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Designations",
                c => new
                    {
                        DesignationId = c.Int(nullable: false, identity: true),
                        DesignationInfo = c.String(),
                    })
                .PrimaryKey(t => t.DesignationId);
            
            CreateTable(
                "dbo.Enrolls",
                c => new
                    {
                        EnrollId = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        GradeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EnrollId)
                .ForeignKey("dbo.Courses", t => t.CourseId)
                .ForeignKey("dbo.Grades", t => t.GradeId)
                .ForeignKey("dbo.Students", t => t.StudentId)
                .Index(t => t.StudentId)
                .Index(t => t.CourseId)
                .Index(t => t.GradeId);
            
            CreateTable(
                "dbo.Grades",
                c => new
                    {
                        GradeId = c.Int(nullable: false, identity: true),
                        GradeLetter = c.String(),
                    })
                .PrimaryKey(t => t.GradeId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        StudentName = c.String(nullable: false, maxLength: 50, unicode: false),
                        Email = c.String(nullable: false, maxLength: 8000, unicode: false),
                        ContactNo = c.String(nullable: false),
                        RegistrationDate = c.DateTime(nullable: false),
                        Address = c.String(),
                        DepartmentId = c.Int(nullable: false),
                        RegNo = c.String(),
                    })
                .PrimaryKey(t => t.StudentId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Results",
                c => new
                    {
                        ResultId = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        GradeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ResultId)
                .ForeignKey("dbo.Courses", t => t.CourseId)
                .ForeignKey("dbo.Grades", t => t.GradeId)
                .ForeignKey("dbo.Students", t => t.StudentId)
                .Index(t => t.StudentId)
                .Index(t => t.CourseId)
                .Index(t => t.GradeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Results", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Results", "GradeId", "dbo.Grades");
            DropForeignKey("dbo.Results", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Enrolls", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Students", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Enrolls", "GradeId", "dbo.Grades");
            DropForeignKey("dbo.Enrolls", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.AssignCourses", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Teachers", "DesignationId", "dbo.Designations");
            DropForeignKey("dbo.Teachers", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.AssignCourses", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.AssignCourses", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Allocations", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.Allocations", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Allocations", "DayId", "dbo.Days");
            DropForeignKey("dbo.Allocations", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Courses", "SemesterId", "dbo.Semesters");
            DropForeignKey("dbo.Courses", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Results", new[] { "GradeId" });
            DropIndex("dbo.Results", new[] { "CourseId" });
            DropIndex("dbo.Results", new[] { "StudentId" });
            DropIndex("dbo.Students", new[] { "DepartmentId" });
            DropIndex("dbo.Enrolls", new[] { "GradeId" });
            DropIndex("dbo.Enrolls", new[] { "CourseId" });
            DropIndex("dbo.Enrolls", new[] { "StudentId" });
            DropIndex("dbo.Teachers", new[] { "DepartmentId" });
            DropIndex("dbo.Teachers", new[] { "DesignationId" });
            DropIndex("dbo.AssignCourses", new[] { "CourseId" });
            DropIndex("dbo.AssignCourses", new[] { "TeacherId" });
            DropIndex("dbo.AssignCourses", new[] { "DepartmentId" });
            DropIndex("dbo.Courses", new[] { "SemesterId" });
            DropIndex("dbo.Courses", new[] { "DepartmentId" });
            DropIndex("dbo.Allocations", new[] { "DayId" });
            DropIndex("dbo.Allocations", new[] { "RoomId" });
            DropIndex("dbo.Allocations", new[] { "CourseId" });
            DropIndex("dbo.Allocations", new[] { "DepartmentId" });
            DropTable("dbo.Results");
            DropTable("dbo.Students");
            DropTable("dbo.Grades");
            DropTable("dbo.Enrolls");
            DropTable("dbo.Designations");
            DropTable("dbo.Teachers");
            DropTable("dbo.AssignCourses");
            DropTable("dbo.Rooms");
            DropTable("dbo.Days");
            DropTable("dbo.Semesters");
            DropTable("dbo.Departments");
            DropTable("dbo.Courses");
            DropTable("dbo.Allocations");
        }
    }
}
