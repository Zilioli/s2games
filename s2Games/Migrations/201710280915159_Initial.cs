namespace s2Games.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.amigo",
                c => new
                    {
                        codigo = c.Int(nullable: false, identity: true),
                        nome = c.String(maxLength: 100),
                        dataExclusao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.codigo);
            
            CreateTable(
                "dbo.emprestimo",
                c => new
                    {
                        codigoAmigo = c.Int(nullable: false),
                        codigoGame = c.Int(nullable: false),
                        dataEmprestimo = c.DateTime(nullable: false),
                        dataDevolucao = c.DateTime(nullable: false),
                        amigo_codigo = c.Int(),
                        game_codigo = c.Int(),
                    })
                .PrimaryKey(t => new { t.codigoAmigo, t.codigoGame })
                .ForeignKey("dbo.amigo", t => t.amigo_codigo)
                .ForeignKey("dbo.game", t => t.game_codigo)
                .Index(t => t.amigo_codigo)
                .Index(t => t.game_codigo);
            
            CreateTable(
                "dbo.game",
                c => new
                    {
                        codigo = c.Int(nullable: false, identity: true),
                        nome = c.String(maxLength: 100),
                        avaliacao = c.Int(nullable: false),
                        dataExclusao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.codigo);
            
            CreateTable(
                "dbo.user",
                c => new
                    {
                        codigo = c.Int(nullable: false, identity: true),
                        nome = c.String(maxLength: 100),
                        login = c.String(maxLength: 10),
                        senha = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.codigo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.emprestimo", "game_codigo", "dbo.game");
            DropForeignKey("dbo.emprestimo", "amigo_codigo", "dbo.amigo");
            DropIndex("dbo.emprestimo", new[] { "game_codigo" });
            DropIndex("dbo.emprestimo", new[] { "amigo_codigo" });
            DropTable("dbo.user");
            DropTable("dbo.game");
            DropTable("dbo.emprestimo");
            DropTable("dbo.amigo");
        }
    }
}
