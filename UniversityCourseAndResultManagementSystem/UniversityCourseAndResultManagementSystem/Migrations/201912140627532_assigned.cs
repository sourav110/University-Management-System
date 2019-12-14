namespace UniversityCourseAndResultManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class assigned : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AssignCourses", "CourseCredit", c => c.String());
            DropColumn("dbo.AssignCourses", "Credit");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AssignCourses", "Credit", c => c.String());
            DropColumn("dbo.AssignCourses", "CourseCredit");
        }
    }
}
