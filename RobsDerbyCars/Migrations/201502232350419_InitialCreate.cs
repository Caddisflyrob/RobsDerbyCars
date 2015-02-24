namespace RobsDerbyCars.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Car",
                c => new
                    {
                        CarID = c.Int(nullable: false, identity: true),
                        CarName = c.String(maxLength: 35),
                        PictureURL = c.String(),
                        ThumbnailURL = c.String(),
                        Description = c.String(),
                        Owner = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.CarID);
            
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        CommentID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 30),
                        CommentText = c.String(maxLength: 255),
                        CarIdNum = c.Int(nullable: false),
                        Car_CarID = c.Int(),
                    })
                .PrimaryKey(t => t.CommentID)
                .ForeignKey("dbo.Car", t => t.Car_CarID)
                .Index(t => t.Car_CarID);
            
            CreateTable(
                "dbo.Division",
                c => new
                    {
                        DivisionID = c.Int(nullable: false, identity: true),
                        DivisionName = c.String(maxLength: 30),
                        PreviousDivisionName = c.String(),
                    })
                .PrimaryKey(t => t.DivisionID);
            
            CreateTable(
                "dbo.Heat",
                c => new
                    {
                        HeatID = c.Int(nullable: false, identity: true),
                        RaceID = c.Int(nullable: false),
                        FirstRacerID = c.Int(nullable: false),
                        SecondRacerID = c.Int(nullable: false),
                        FirstRacerIsWinner = c.Boolean(nullable: false),
                        SecondRacerIsWinner = c.Boolean(nullable: false),
                        IsComplete = c.Boolean(nullable: false),
                        Division = c.String(),
                        FirstRacerName = c.String(),
                        SecondRacerName = c.String(),
                    })
                .PrimaryKey(t => t.HeatID)
                .ForeignKey("dbo.Race", t => t.RaceID, cascadeDelete: true)
                .Index(t => t.RaceID);
            
            CreateTable(
                "dbo.Racer",
                c => new
                    {
                        RacerID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Division = c.String(),
                        NumWins = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RacerID);
            
            CreateTable(
                "dbo.Race",
                c => new
                    {
                        RaceID = c.Int(nullable: false, identity: true),
                        DivisionName = c.String(),
                    })
                .PrimaryKey(t => t.RaceID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Heat", "RaceID", "dbo.Race");
            DropForeignKey("dbo.Comment", "Car_CarID", "dbo.Car");
            DropIndex("dbo.Heat", new[] { "RaceID" });
            DropIndex("dbo.Comment", new[] { "Car_CarID" });
            DropTable("dbo.Race");
            DropTable("dbo.Racer");
            DropTable("dbo.Heat");
            DropTable("dbo.Division");
            DropTable("dbo.Comment");
            DropTable("dbo.Car");
        }
    }
}
