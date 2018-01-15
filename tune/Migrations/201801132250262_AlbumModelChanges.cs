namespace tune.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlbumModelChanges : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Albums", "NumberInStock", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Albums", "NumberInStock", c => c.Int(nullable: false));
        }
    }
}
