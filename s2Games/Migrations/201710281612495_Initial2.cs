namespace s2Games.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.user", "login", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.user", "senha", c => c.String(nullable: false, maxLength: 150));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.user", "senha", c => c.String(maxLength: 150));
            AlterColumn("dbo.user", "login", c => c.String(maxLength: 10));
        }
    }
}
