namespace Geldactiviteiten_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitalCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Doels",
                c => new
                    {
                        DoelId = c.Int(nullable: false, identity: true),
                        Naam = c.String(),
                    })
                .PrimaryKey(t => t.DoelId);
            
            CreateTable(
                "dbo.Geldactiviteit_Doel",
                c => new
                    {
                        Geldactiviteit_DoelId = c.Int(nullable: false, identity: true),
                        DoelId = c.Int(nullable: false),
                        GeldactiviteitId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Geldactiviteit_DoelId)
                .ForeignKey("dbo.Doels", t => t.DoelId, cascadeDelete: true)
                .ForeignKey("dbo.Geldactiviteits", t => t.GeldactiviteitId, cascadeDelete: true)
                .Index(t => t.DoelId)
                .Index(t => t.GeldactiviteitId);
            
            CreateTable(
                "dbo.Geldactiviteits",
                c => new
                    {
                        GeldactiviteitId = c.Int(nullable: false, identity: true),
                        Omschrijving = c.String(),
                        ToDo = c.String(),
                        Wanneer = c.String(),
                        Kosten = c.String(),
                        Inkomsten = c.String(),
                        SoortId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GeldactiviteitId)
                .ForeignKey("dbo.Soorts", t => t.SoortId, cascadeDelete: true)
                .Index(t => t.SoortId);
            
            CreateTable(
                "dbo.Geldactiviteit_Doelpubliek",
                c => new
                    {
                        Geldactiviteit_DoelpubliekId = c.Int(nullable: false, identity: true),
                        DoelpubliekId = c.Int(nullable: false),
                        GeldactiviteitId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Geldactiviteit_DoelpubliekId)
                .ForeignKey("dbo.Doelpublieks", t => t.DoelpubliekId, cascadeDelete: true)
                .ForeignKey("dbo.Geldactiviteits", t => t.GeldactiviteitId, cascadeDelete: true)
                .Index(t => t.DoelpubliekId)
                .Index(t => t.GeldactiviteitId);
            
            CreateTable(
                "dbo.Doelpublieks",
                c => new
                    {
                        DoelpubliekId = c.Int(nullable: false, identity: true),
                        Naam = c.String(),
                    })
                .PrimaryKey(t => t.DoelpubliekId);
            
            CreateTable(
                "dbo.Geldactiviteit_Tijdstip",
                c => new
                    {
                        Geldactiviteit_TijdstipId = c.Int(nullable: false, identity: true),
                        TijdstipId = c.Int(nullable: false),
                        GeldactiviteitId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Geldactiviteit_TijdstipId)
                .ForeignKey("dbo.Geldactiviteits", t => t.GeldactiviteitId, cascadeDelete: true)
                .ForeignKey("dbo.Tijdstips", t => t.TijdstipId, cascadeDelete: true)
                .Index(t => t.TijdstipId)
                .Index(t => t.GeldactiviteitId);
            
            CreateTable(
                "dbo.Tijdstips",
                c => new
                    {
                        TijdstipId = c.Int(nullable: false, identity: true),
                        Naam = c.String(),
                    })
                .PrimaryKey(t => t.TijdstipId);
            
            CreateTable(
                "dbo.Soorts",
                c => new
                    {
                        SoortId = c.Int(nullable: false, identity: true),
                        Naam = c.String(),
                    })
                .PrimaryKey(t => t.SoortId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Geldactiviteits", "SoortId", "dbo.Soorts");
            DropForeignKey("dbo.Geldactiviteit_Tijdstip", "TijdstipId", "dbo.Tijdstips");
            DropForeignKey("dbo.Geldactiviteit_Tijdstip", "GeldactiviteitId", "dbo.Geldactiviteits");
            DropForeignKey("dbo.Geldactiviteit_Doelpubliek", "GeldactiviteitId", "dbo.Geldactiviteits");
            DropForeignKey("dbo.Geldactiviteit_Doelpubliek", "DoelpubliekId", "dbo.Doelpublieks");
            DropForeignKey("dbo.Geldactiviteit_Doel", "GeldactiviteitId", "dbo.Geldactiviteits");
            DropForeignKey("dbo.Geldactiviteit_Doel", "DoelId", "dbo.Doels");
            DropIndex("dbo.Geldactiviteit_Tijdstip", new[] { "GeldactiviteitId" });
            DropIndex("dbo.Geldactiviteit_Tijdstip", new[] { "TijdstipId" });
            DropIndex("dbo.Geldactiviteit_Doelpubliek", new[] { "GeldactiviteitId" });
            DropIndex("dbo.Geldactiviteit_Doelpubliek", new[] { "DoelpubliekId" });
            DropIndex("dbo.Geldactiviteits", new[] { "SoortId" });
            DropIndex("dbo.Geldactiviteit_Doel", new[] { "GeldactiviteitId" });
            DropIndex("dbo.Geldactiviteit_Doel", new[] { "DoelId" });
            DropTable("dbo.Soorts");
            DropTable("dbo.Tijdstips");
            DropTable("dbo.Geldactiviteit_Tijdstip");
            DropTable("dbo.Doelpublieks");
            DropTable("dbo.Geldactiviteit_Doelpubliek");
            DropTable("dbo.Geldactiviteits");
            DropTable("dbo.Geldactiviteit_Doel");
            DropTable("dbo.Doels");
        }
    }
}
