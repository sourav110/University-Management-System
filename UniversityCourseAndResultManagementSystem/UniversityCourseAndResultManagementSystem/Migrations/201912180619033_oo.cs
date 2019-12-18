namespace UniversityCourseAndResultManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class oo : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Enrolls", new[] { "GradeId" });
            RenameColumn(table: "dbo.Enrolls", name: "GradeId", newName: "Grade_GradeId");
            AlterColumn("dbo.Enrolls", "Grade_GradeId", c => c.Int());
            CreateIndex("dbo.Enrolls", "Grade_GradeId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Enrolls", new[] { "Grade_GradeId" });
            AlterColumn("dbo.Enrolls", "Grade_GradeId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Enrolls", name: "Grade_GradeId", newName: "GradeId");
            CreateIndex("dbo.Enrolls", "GradeId");
        }
    }
}
