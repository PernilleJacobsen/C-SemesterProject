namespace DatabaseFirst
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SCHOOL : DbContext
    {
        public SCHOOL()
            : base("name=PETSDB")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Cats> Cats { get; set; }
        public virtual DbSet<Clubs> Clubs { get; set; }
        public virtual DbSet<Dogs> Dogs { get; set; }
        public virtual DbSet<People> People { get; set; }
        public virtual DbSet<Pets> Pets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clubs>()
                .HasMany(e => e.People1)
                .WithMany(e => e.Clubs1)
                .Map(m => m.ToTable("PersonClubs").MapLeftKey("Club_Code").MapRightKey("Person_Id"));

            modelBuilder.Entity<People>()
                .HasMany(e => e.Clubs)
                .WithOptional(e => e.People)
                .HasForeignKey(e => e.Chairman_Id);

            modelBuilder.Entity<People>()
                .HasMany(e => e.Pets)
                .WithOptional(e => e.People)
                .HasForeignKey(e => e.Owner_Id);

            modelBuilder.Entity<Pets>()
                .HasOptional(e => e.Cats)
                .WithRequired(e => e.Pets);

            modelBuilder.Entity<Pets>()
                .HasOptional(e => e.Dogs)
                .WithRequired(e => e.Pets);
        }
    }
}
