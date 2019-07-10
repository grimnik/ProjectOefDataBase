namespace DeelnemersLijstBeheer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Deelnemers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naam = c.String(),
                        GeboorteDatum = c.DateTime(nullable: false),
                        WoonPlaats = c.String(),
                        BadgeNummer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Docentens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naam = c.String(),
                        Bedrijf = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OpleidingsInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Instelling = c.String(),
                        Opleiding = c.String(),
                        ContactPersoon = c.String(),
                        OpleidingsPlaats = c.String(),
                        RefOpleidingsPlaats = c.String(),
                        StartDatum = c.DateTime(nullable: false),
                        EindDatum = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tijdregistraties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        OpleidingId = c.Int(nullable: false),
                        DeelnemerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tijdregistraties");
            DropTable("dbo.OpleidingsInfoes");
            DropTable("dbo.Docentens");
            DropTable("dbo.Deelnemers");
        }
    }
}
