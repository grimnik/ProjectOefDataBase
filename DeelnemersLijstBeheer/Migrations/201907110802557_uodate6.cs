namespace DeelnemersLijstBeheer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class uodate6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OpleidingsInfoes", "OeNummer", c => c.Int(nullable: false));
            AddColumn("dbo.OpleidingsInfoes", "OpleidingsCode", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OpleidingsInfoes", "OpleidingsCode");
            DropColumn("dbo.OpleidingsInfoes", "OeNummer");
        }
    }
}
