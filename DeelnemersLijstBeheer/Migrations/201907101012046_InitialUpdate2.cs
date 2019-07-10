namespace DeelnemersLijstBeheer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialUpdate2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NietOpleidingsDagens", "OpleidingsInfo_Id", c => c.Int());
            AddColumn("dbo.Tijdregistraties", "Deelnemers_Id", c => c.Int());
            CreateIndex("dbo.NietOpleidingsDagens", "OpleidingsInfo_Id");
            CreateIndex("dbo.Tijdregistraties", "Deelnemers_Id");
            AddForeignKey("dbo.NietOpleidingsDagens", "OpleidingsInfo_Id", "dbo.OpleidingsInfoes", "Id");
            AddForeignKey("dbo.Tijdregistraties", "Deelnemers_Id", "dbo.Deelnemers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tijdregistraties", "Deelnemers_Id", "dbo.Deelnemers");
            DropForeignKey("dbo.NietOpleidingsDagens", "OpleidingsInfo_Id", "dbo.OpleidingsInfoes");
            DropIndex("dbo.Tijdregistraties", new[] { "Deelnemers_Id" });
            DropIndex("dbo.NietOpleidingsDagens", new[] { "OpleidingsInfo_Id" });
            DropColumn("dbo.Tijdregistraties", "Deelnemers_Id");
            DropColumn("dbo.NietOpleidingsDagens", "OpleidingsInfo_Id");
        }
    }
}
