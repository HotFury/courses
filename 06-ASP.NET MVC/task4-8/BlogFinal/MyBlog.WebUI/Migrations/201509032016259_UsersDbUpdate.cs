namespace MyBlog.WebUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UsersDbUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Active", c => c.Boolean(nullable: true));
            
            CreateTable(
                "dbo.Votes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        User = c.Int(nullable: false),
                        Rate = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Votes");
            DropColumn("dbo.Users", "Active");
        }
    }
}
