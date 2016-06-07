namespace DatabaseFirstExample2
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Context : DbContext
    {
        public Context()
            : base("name=Context")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Persons> Persons { get; set; }
        public virtual DbSet<Students> Students { get; set; }
        public virtual DbSet<Teachers> Teachers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Persons>()
                .HasOptional(e => e.Students)
                .WithRequired(e => e.Persons);

            modelBuilder.Entity<Persons>()
                .HasOptional(e => e.Teachers)
                .WithRequired(e => e.Persons);
        }
    }
}
