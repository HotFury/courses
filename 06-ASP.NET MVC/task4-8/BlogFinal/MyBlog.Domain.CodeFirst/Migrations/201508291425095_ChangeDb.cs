namespace MyBlog.Domain.CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Articles", "Deleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Articles", "Deleted");
        }
    }
}
