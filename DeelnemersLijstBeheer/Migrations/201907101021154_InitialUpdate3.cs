namespace DeelnemersLijstBeheer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialUpdate3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tijdregistraties", "OpleidingsInfo_Id", c => c.Int());
            CreateIndex("dbo.Tijdregistraties", "OpleidingsInfo_Id");
            AddForeignKey("dbo.Tijdregistraties", "OpleidingsInfo_Id", "dbo.OpleidingsInfoes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tijdregistraties", "OpleidingsInfo_Id", "dbo.OpleidingsInfoes");
            DropIndex("dbo.Tijdregistraties", new[] { "OpleidingsInfo_Id" });
            DropColumn("dbo.Tijdregistraties", "OpleidingsInfo_Id");
        }
    }
}
