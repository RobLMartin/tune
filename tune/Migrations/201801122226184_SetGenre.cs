namespace tune.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetGenre : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id, Name) VALUES (1, 'Folk')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (2, 'Rock')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (3, 'Acoustic')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (4, 'Hip Hop')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (5, 'Indie')");
        }
        
        public override void Down()
        {
        }
    }
}
