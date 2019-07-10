namespace DeelnemersLijstBeheer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialUpdate1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NietOpleidingsDagens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Datum = c.DateTime(nullable: false),
                        Voormiddag = c.Boolean(nullable: false),
                        Namiddag = c.Boolean(nullable: false),
                        OpleidingsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Deelnemers", "OpleidingsInfo_Id", c => c.Int());
            AddColumn("dbo.Docentens", "OpleidingsInfo_Id", c => c.Int());
            CreateIndex("dbo.Deelnemers", "OpleidingsInfo_Id");
            CreateIndex("dbo.Docentens", "OpleidingsInfo_Id");
            AddForeignKey("dbo.Deelnemers", "OpleidingsInfo_Id", "dbo.OpleidingsInfoes", "Id");
            AddForeignKey("dbo.Docentens", "OpleidingsInfo_Id", "dbo.OpleidingsInfoes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Docentens", "OpleidingsInfo_Id", "dbo.OpleidingsInfoes");
            DropForeignKey("dbo.Deelnemers", "OpleidingsInfo_Id", "dbo.OpleidingsInfoes");
            DropIndex("dbo.Docentens", new[] { "OpleidingsInfo_Id" });
            DropIndex("dbo.Deelnemers", new[] { "OpleidingsInfo_Id" });
            DropColumn("dbo.Docentens", "OpleidingsInfo_Id");
            DropColumn("dbo.Deelnemers", "OpleidingsInfo_Id");
            DropTable("dbo.NietOpleidingsDagens");
        }
    }
}
