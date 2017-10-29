namespace s2Games.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.amigo", "dataExclusao", c => c.DateTime());
            AlterColumn("dbo.emprestimo", "dataDevolucao", c => c.DateTime());
            AlterColumn("dbo.game", "dataExclusao", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.game", "dataExclusao", c => c.DateTime(nullable: false));
            AlterColumn("dbo.emprestimo", "dataDevolucao", c => c.DateTime(nullable: false));
            AlterColumn("dbo.amigo", "dataExclusao", c => c.DateTime(nullable: false));
        }
    }
}
