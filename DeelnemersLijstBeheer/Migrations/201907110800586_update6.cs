namespace DeelnemersLijstBeheer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update6 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Tijdregistraties", "OpleidingId");
            DropColumn("dbo.Tijdregistraties", "DeelnemerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tijdregistraties", "DeelnemerId", c => c.Int(nullable: false));
            AddColumn("dbo.Tijdregistraties", "OpleidingId", c => c.Int(nullable: false));
        }
    }
}
