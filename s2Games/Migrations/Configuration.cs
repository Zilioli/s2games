namespace s2Games.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DropCreateDatabaseAlways<s2Games.dbGame>
    {
        public Configuration()
        {
            
       }

        protected override void Seed(s2Games.dbGame context)
        {
            context.users.Add(new user() { nome="Administrador", login="adms2", senha="123456" });

            context.games.Add( new game() { nome = "GOD OF WAR" });
            context.games.Add(new game() { nome = "FINAL FANTASY" });
            context.games.Add(new game() { nome = "FIFA 2017" });
            context.games.Add(new game() { nome = "GUITAR HERO" });
            context.games.Add(new game() { nome = "METAL GEAR SOLID" });
            context.games.Add(new game() { nome = "PRO EVOLUTION SOCCER" });
            context.games.Add(new game() { nome = "TEKKEN 3" });
            
            context.amigos.Add(new amigo() { nome = "Luiz"});
            context.amigos.Add(new amigo() { nome = "Sergio" });
            context.amigos.Add(new amigo() { nome = "Jair" });
            context.amigos.Add(new amigo() { nome = "Inácio" });

            context.emprestimos.Add(new emprestimo() { codigoAmigo = 1, codigoGame = 1,dataEmprestimo = DateTime.Now});
            context.emprestimos.Add(new emprestimo() { codigoAmigo = 3, codigoGame = 5, dataEmprestimo = DateTime.Now });

            //
        }
    }
}
