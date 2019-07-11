namespace DeelnemersLijstBeheer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialupdate4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Docentens", "OpleidingsInfo_Id", "dbo.OpleidingsInfoes");
            DropIndex("dbo.Docentens", new[] { "OpleidingsInfo_Id" });
            CreateTable(
                "dbo.DocentCourse",
                c => new
                    {
                        DocentRefId = c.Int(nullable: false),
                        CourseRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DocentRefId, t.CourseRefId })
                .ForeignKey("dbo.OpleidingsInfoes", t => t.CourseRefId, cascadeDelete: true)
                .ForeignKey("dbo.Docentens", t => t.DocentRefId, cascadeDelete: true)
                .Index(t => t.DocentRefId)
                .Index(t => t.CourseRefId);
            
            DropColumn("dbo.Docentens", "OpleidingsInfo_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Docentens", "OpleidingsInfo_Id", c => c.Int());
            DropForeignKey("dbo.DocentCourse", "CourseRefId", "dbo.Docentens");
            DropForeignKey("dbo.DocentCourse", "DocentRefId", "dbo.OpleidingsInfoes");
            DropIndex("dbo.DocentCourse", new[] { "CourseRefId" });
            DropIndex("dbo.DocentCourse", new[] { "DocentRefId" });
            DropTable("dbo.DocentCourse");
            CreateIndex("dbo.Docentens", "OpleidingsInfo_Id");
            AddForeignKey("dbo.Docentens", "OpleidingsInfo_Id", "dbo.OpleidingsInfoes", "Id");
        }
    }
}
