namespace UniversityCourseAndResultManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class assignNew : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.AssignCourses", "DepartmentId");
            CreateIndex("dbo.AssignCourses", "TeacherId");
            AddForeignKey("dbo.AssignCourses", "DepartmentId", "dbo.Departments", "DepartmentId");
            AddForeignKey("dbo.AssignCourses", "TeacherId", "dbo.Teachers", "TeacherId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AssignCourses", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.AssignCourses", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.AssignCourses", new[] { "TeacherId" });
            DropIndex("dbo.AssignCourses", new[] { "DepartmentId" });
        }
    }
}
