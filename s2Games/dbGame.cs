namespace s2Games
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using s2Games.Models;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using Migrations;

    public partial class dbGame : DbContext
    {

        public DbSet<game> games { get; set; }
        public DbSet<amigo> amigos { get; set; }
        public DbSet<emprestimo> emprestimos { get; set; }
        public DbSet<user> users { get; set; }

        public dbGame()
            : base("name=dbGame")
        {
            Database.SetInitializer(new Configuration());

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        }

    }
}
