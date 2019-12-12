namespace UniversityCourseAndResultManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class allocations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Allocations",
                c => new
                    {
                        AllocationId = c.Int(nullable: false, identity: true),
                        DepartmentId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        RoomId = c.Int(nullable: false),
                        DayId = c.Int(nullable: false),
                        FromTime = c.String(),
                        ToTime = c.String(),
                    })
                .PrimaryKey(t => t.AllocationId)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Days", t => t.DayId, cascadeDelete: true)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: true)
                .Index(t => t.CourseId)
                .Index(t => t.RoomId)
                .Index(t => t.DayId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Allocations", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.Allocations", "DayId", "dbo.Days");
            DropForeignKey("dbo.Allocations", "CourseId", "dbo.Courses");
            DropIndex("dbo.Allocations", new[] { "DayId" });
            DropIndex("dbo.Allocations", new[] { "RoomId" });
            DropIndex("dbo.Allocations", new[] { "CourseId" });
            DropTable("dbo.Allocations");
        }
    }
}
