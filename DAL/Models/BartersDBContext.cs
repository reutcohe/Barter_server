using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DAL.Models
{
    public partial class BartersDBContext : DbContext
    {
        public BartersDBContext()
        {
        }

        public BartersDBContext(DbContextOptions<BartersDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<CategoryUser> CategoryUsers { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<CustomerInquiry> CustomerInquiries { get; set; }
        public virtual DbSet<Massage> Massages { get; set; }
        public virtual DbSet<Opinion> Opinions { get; set; }
        public virtual DbSet<Publication> Publications { get; set; }
        public virtual DbSet<Star> Stars { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\ProjectModels;Database=BartersDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.CategoryName).IsRequired();
            });

            modelBuilder.Entity<CategoryUser>(entity =>
            {
                entity.ToTable("Category- User");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Categoty)
                    .WithMany(p => p.CategoryUsers)
                    .HasForeignKey(d => d.CategotyId)
                    .HasConstraintName("FK_Category- User_Category");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CategoryUsers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Category- User_Users");
            });

            modelBuilder.Entity<CustomerInquiry>(entity =>
            {
                entity.Property(e => e.TurnDate).HasColumnType("date");
            });

            modelBuilder.Entity<Massage>(entity =>
            {
                entity.Property(e => e.MassageDate).HasColumnType("date");
            });

            modelBuilder.Entity<Opinion>(entity =>
            {
                entity.ToTable("Opinion");

                entity.Property(e => e.DateAdded).HasColumnType("date");

                entity.HasOne(d => d.Drage)
                    .WithMany(p => p.Opinions)
                    .HasForeignKey(d => d.DrageId)
                    .HasConstraintName("FK_Opinion_Users");
            });

            modelBuilder.Entity<Publication>(entity =>
            {
                entity.ToTable("Publication");

                entity.Property(e => e.ClosingDate).HasColumnType("date");

                entity.Property(e => e.PublicationDate).HasColumnType("date");

                entity.HasOne(d => d.CategoryIdNeedNavigation)
                    .WithMany(p => p.Publications)
                    .HasForeignKey(d => d.CategoryIdNeed)
                    .HasConstraintName("FK_Publication_Category");

                entity.HasOne(d => d.UserIdPublishNavigation)
                    .WithMany(p => p.Publications)
                    .HasForeignKey(d => d.UserIdPublish)
                    .HasConstraintName("FK_Publication_Users");
            });

            modelBuilder.Entity<Star>(entity =>
            {
                entity.Property(e => e.DateGiven).HasColumnType("date");

                entity.Property(e => e.DateReceived).HasColumnType("date");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_Users_Cities");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.User)
                    .HasForeignKey<User>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_CustomerInquiries");

                entity.HasOne(d => d.Id1)
                    .WithOne(p => p.User)
                    .HasForeignKey<User>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_Massages");

                entity.HasOne(d => d.Id2)
                    .WithOne(p => p.User)
                    .HasForeignKey<User>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_Stars");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
