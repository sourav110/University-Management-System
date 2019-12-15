namespace UniversityCourseAndResultManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class studentregno : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "RegNo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "RegNo");
        }
    }
}
