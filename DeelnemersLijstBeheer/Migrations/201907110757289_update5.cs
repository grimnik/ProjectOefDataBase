namespace DeelnemersLijstBeheer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Deelnemers", "OpleidingsInfo_Id", "dbo.OpleidingsInfoes");
            DropIndex("dbo.Deelnemers", new[] { "OpleidingsInfo_Id" });
            CreateTable(
                "dbo.DeelnemersOpleidingen",
                c => new
                    {
                        DeelnemersId = c.Int(nullable: false),
                        OpleidingId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DeelnemersId, t.OpleidingId })
                .ForeignKey("dbo.OpleidingsInfoes", t => t.OpleidingId, cascadeDelete: true)
                .ForeignKey("dbo.Deelnemers", t => t.DeelnemersId, cascadeDelete: true)
                .Index(t => t.DeelnemersId)
                .Index(t => t.OpleidingId);
            
            DropColumn("dbo.Deelnemers", "OpleidingsInfo_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Deelnemers", "OpleidingsInfo_Id", c => c.Int());
            DropForeignKey("dbo.DeelnemersOpleidingen", "OpleidingId", "dbo.Deelnemers");
            DropForeignKey("dbo.DeelnemersOpleidingen", "DeelnemersId", "dbo.OpleidingsInfoes");
            DropIndex("dbo.DeelnemersOpleidingen", new[] { "OpleidingId" });
            DropIndex("dbo.DeelnemersOpleidingen", new[] { "DeelnemersId" });
            DropTable("dbo.DeelnemersOpleidingen");
            CreateIndex("dbo.Deelnemers", "OpleidingsInfo_Id");
            AddForeignKey("dbo.Deelnemers", "OpleidingsInfo_Id", "dbo.OpleidingsInfoes", "Id");
        }
    }
}
